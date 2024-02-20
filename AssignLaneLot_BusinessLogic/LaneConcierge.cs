using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssignLaneLot_DataAccess;

namespace AssignLaneLot_BusinessLogic
{
    public class LaneConcierge
    {
        public string SellerID { get; private set; }
        public string SellerName { get; private set; }
        public string VIN { get; private set; }
        public string SaleDate { get; set; }
        public DataTable OpenReservations { get; private set; }
        private DateTime LastSearchTime { get; set; }

        private StockInVehicleDescription VehicleDescription;
        private readonly StockInGateway StockIn;
        private readonly InventoryGateway Inventory;
        private readonly LaneLotGateway Lots;
        private readonly DealerGateway Sellers;
        

        public LaneConcierge(string sellerId, string vin, string dbConnectionString)
        {
            StockIn = new StockInGateway(dbConnectionString);
            Inventory = new InventoryGateway(dbConnectionString);
            Lots = new LaneLotGateway(dbConnectionString);
            Sellers = new DealerGateway(dbConnectionString);

            SetSellerID(sellerId);
            SetSellerName(Sellers.SellerName(sellerId));
            SetNextSaleDate();
            SetVIN(vin);
            SetVehicleDescription(new StockInVehicleDescription(StockInRecordFor(vin)));
        }

        public void CheckForExistingLotAssignment(
            string vin, 
            ExistingLotAssignmentResponse responseIfFound, 
            DifferentSellerExistingLotAssignmentResponse responseIfFoundDifferentSeller)
        {
            DataRowCollection assignedLots = Lots.LotsAssignedToVIN(vin);

            // If the VIN has a lot assigned to it, (which is the maximum number of lot assignments a VIN should have)
            if (assignedLots.Count == 1)
            {
                DataRow lotAssignment = assignedLots[0];
                var lotSellerId = lotAssignment[LaneLotColumn.Seller].ToString();
                var lotNumber = new LaneLotNumber(lotAssignment[LaneLotColumn.LaneLotNumber].ToString());

                bool reservedForCurrentSeller = lotSellerId == SellerID;
                if (reservedForCurrentSeller)
                {
                    responseIfFound(vin, lotNumber);
                }
                else
                {
                    string lotSellerName = Sellers.SellerName(lotSellerId);
                    responseIfFoundDifferentSeller(vin, lotNumber, new Seller(lotSellerId, lotSellerName));
                }
            }
            // If it has more than one lot assigned to it, (which a VIN never should)
            else if (assignedLots.Count > 1)
            {
                // TODO: What if it has multiple lots assigned to it?
            }
            else // it doesn't have any lots assigned to it.
            {
                // Do nothing.
            }
        }

        public void ConductOpenReservationsSearchForSeller()
        {
            OpenReservations = GetOpenLaneLotReservations();
            LastSearchTime = DateTime.Now;
        }

        public bool HasFoundOpenReservationsForSeller()
        {
            return OpenReservations.Rows.Count > 0;
        }

        public StockInVehicleDescription GetVehicleDescription()
        {
            return VehicleDescription;
        }

        public SellerLineup GetSellerLineup()
        {
            var lineup = new SellerLineup();

            DataRowCollection lotAssignments = Lots.AssignedLotsInSaleForSeller(SaleDate, SellerID);
            foreach (DataRow lotAssignment in lotAssignments)
            {
                // TODO: If the lane / lot's seller is not the same as the seller we're reserving for OR
                    // the lane / lot's saledate is not the one targeted by this reserving

                // The lot's sale date
                string saleDateData = lotAssignment[LaneLotColumn.SaleDate].ToString(); // the LaneLot table's SaleDate column format: 20210728
                int yyyy = int.Parse(saleDateData.Substring(0, 4));
                int mm = int.Parse(saleDateData.Substring(4, 2));
                int dd = int.Parse(saleDateData.Substring(6, 2));
                var saleDate = new DateTime(yyyy, mm, dd);

                // The seller for which the lot is reserved
                string id = lotAssignment[LaneLotColumn.Seller].ToString();
                string name = SellerName;
                var seller = new Seller(id, name);

                // The lot's number and its lane's number
                string laneLotNumber = lotAssignment[LaneLotColumn.LaneLotNumber].ToString();
                var number = new LaneLotNumber(laneLotNumber);

                // The vehicle the lot is assigned to
                string vin = lotAssignment[LaneLotColumn.AssignedVIN].ToString();

                // TODO: What to do if some or all of these values are invalid, null, or empty, etc.?
                var vehicleDescription = new InventoryVehicleDescription(InventoryRecordFor(vin));
                short year = Convert.ToInt16(vehicleDescription.Year);
                string make = vehicleDescription.Make.ToString();
                string model = vehicleDescription.Model.ToString();
                string trim = vehicleDescription.Trim.ToString();
                string body = vehicleDescription.Body.ToString();
                int mileage = Convert.ToInt32(lotAssignment[LaneLotColumn.AssignedVehicleMileage]);

                var vehicle = new Vehicle(vin, year, make, model, trim, body, mileage);

                lineup.Add(new AssignedLot(saleDate, seller, number, vehicle));
            }

            return lineup;
        }

        public bool ReservationStillOpen(string laneLot)
        {
            // Get from the LaneConcierge's store of reservations the one selected by the user.
            DataRow reservationInHand = OpenReservations.Select($"LaneLotNumber = '{laneLot}'").First();

            // The LaneLot of the reservation from the LaneConcierge's store should match the LaneLot the user selected.
            bool isCorrectReservation = reservationInHand[(int)LaneLotColumnIndex.LaneLotNumber].ToString().Equals(laneLot);
            Debug.Assert(isCorrectReservation, "Didn't find the correct reservation. (ERROR CODE: 1)");

            bool open;

            // If 60 seconds or more have elapsed since the user last searched for open reservations
            if (DateTime.Now >= LastSearchTime.AddSeconds(60d))
            {
                // Check if the reservation is still open.
                if (IsOpen(reservationInHand))
                {
                    open = true;
                }
                else
                {
                    open = false;
                }
            }
            else // the reservation is still open.
            {
                open = true;
            }

            return open;
        }

        public AssignmentResult Confirmation(string laneLot)
        {
            return new AssignmentResult(VIN, SellerID, SellerName, laneLot, status: AssignmentResultStatus.Proceed);
        }

        public AssignmentResult Cancellation()
        {
            return new AssignmentResult(VIN, SellerID, SellerName, "", AssignmentResultStatus.Abort);
        }

        private void SetNextSaleDate()
        {
            SaleDate = Lots.NextSaleDate();
        }

        private void SetVIN(string vin)
        {
            VIN = vin;
        }

        private void SetVehicleDescription(StockInVehicleDescription description)
        {
            VehicleDescription = description;
        }

        private void SetSellerID(string number)
        {
            SellerID = number;
        }

        private void SetSellerName(string name)
        {
            SellerName = name;
        }

        private DataTable GetOpenLaneLotReservations()
        {
            return Lots.OpenLotsInSaleForSeller(SaleDate, SellerID);
        }

        private bool IsOpen(DataRow reservationInHand)
        {
            string laneLotNumber = reservationInHand[(int)LaneLotColumnIndex.LaneLotNumber].ToString();

            // TODO: Defensive code around the following call to get the reservation's current version in the db.

            // Get the reservation from the database again.
            DataRow reservationNow =
                Lots.Lot(SaleDate, SellerID, laneLotNumber);

            // The current version of the reservation in the database should equal the version of it being held by the LaneConcierge.
            bool areSame = reservationNow[(int)LaneLotColumnIndex.LaneLotNumber].ToString().Equals(reservationInHand[(int)LaneLotColumnIndex.LaneLotNumber].ToString());
            Debug.Assert(areSame, "Didn't find the same reservation. (ERROR CODE: 2)");

            // Check whether the current version of the reservation is still open.
            return reservationNow[(int)LaneLotColumnIndex.SellType].ToString() == "G";
        }

        private DataRow StockInRecordFor(string vin)
        {
            DataRow record;
            DataRowCollection stockInRecords = StockIn.StockInRecordsForVehicle(vin);

            // If we received only one record back
            if (stockInRecords.Count == 1)
            {
                // That's the record.
                record = stockInRecords[0];
            }
            // If we received multiple records back
            else if (stockInRecords.Count > 1)
            {
                // Determine which record to use...

                DataRow recordCandidate = stockInRecords[0];
                var latestStockInDate = new DateTime(0001, 1, 1);

                foreach (DataRow stockInRec in stockInRecords)
                {
                    DateTime stockInDate = (DateTime)stockInRec[StockInColumn.StockInDate];

                    if (stockInDate > latestStockInDate)
                    {
                        latestStockInDate = stockInDate;
                        recordCandidate = stockInRec;
                    }
                    // TODO: What if they have the same stock-in date/time?
                }

                record = recordCandidate;
            }
            else
            {
                // We should always receive at least one record back.
                Debug.Assert(stockInRecords.Count >= 1, $"No Stock-In records found for {vin}");

                // TODO: Something better than null.
                record = null;
            }

            return record;
        }

        private DataRow InventoryRecordFor(string vin)
        {
            DataRow record;
            DataRowCollection inventoryRecords = Inventory.InventoryRecordsForVehicle(vin);

            // If we received only one record back
            if (inventoryRecords.Count == 1)
            {
                // That's the record.
                record = inventoryRecords[0];
            }
            // If we received multiple records back
            else if (inventoryRecords.Count > 1)
            {
                // Determine which record to use...

                DataRow recordCandidate = inventoryRecords[0];
                var latestStockInDate = new DateTime(0001, 1, 1);

                foreach (DataRow invRecord in inventoryRecords)
                {
                    string rawStockInDate = invRecord[InventoryColumn.InventoryDate].ToString();

                    // If the date's raw representation has a single-digit month without a leading 0
                    if (rawStockInDate.Length == 5)
                    {
                        // Prepend 0 to it.
                        rawStockInDate = '0' + rawStockInDate;
                    }

                    // TODO: Confirm that the raw representation can be parsed into a date-time object.

                    // If it can be parsed, then parse it.
                    DateTime stockInDate = DateTime.ParseExact(rawStockInDate, "MMddyy", CultureInfo.InvariantCulture);

                    // TODO: If it can't be parsed...

                    if (stockInDate > latestStockInDate)
                    {
                        latestStockInDate = stockInDate;
                        recordCandidate = invRecord;
                    }
                    // TODO: What if they have the same stock-in date/time?
                }

                record = recordCandidate;
            }
            else
            {
                // We should always receive at least one record back.
                Debug.Assert(inventoryRecords.Count >= 1, $"No inventory records found for {vin}");

                // TODO: Something better than null.
                record = null;
            }

            return record;
        }
    }
}

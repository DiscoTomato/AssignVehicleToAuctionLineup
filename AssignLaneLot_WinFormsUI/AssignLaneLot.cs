using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AssignLaneLot_BusinessLogic;

namespace AssignLaneLot_WinFormsUI
{
    public partial class AssignLaneLot : Form
    {
        private readonly LaneConcierge Concierge;
        private readonly ResultDeliveryMethod ResultDeliveryMethod;


        public AssignLaneLot(string vin, string sellerId, string dbConnectionString, ResultDeliveryMethod resultDeliveryMethod)
        {
            InitializeComponent();
            Concierge = new LaneConcierge(sellerId, vin, dbConnectionString);
            ResultDeliveryMethod = resultDeliveryMethod;
        }

        private void AssignLaneLot_Load(object sender, EventArgs e)
        {
            DisplayNextSaleDate();
            DisplayReservingSellerInformation();
            DisplayReservingVehicleInformation();

            Shown += AssignLaneLot_Shown;
        }

        private void DisplayNextSaleDate()
        {
            DateTime saleDate = DateTime.ParseExact(Concierge.SaleDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            SaleDate.Text = $"{saleDate.Month}/{saleDate.Day}/{saleDate.Year}";
        }

        private void DisplayReservingSellerInformation()
        {
            SellerInfo.Text = $"{Concierge.SellerName}\n\n{Concierge.SellerID}";
        }

        private void DisplayReservingVehicleInformation()
        {
            string vin = Concierge.VIN;
            string year = Concierge.GetVehicleDescription().Year.ToString(); // TODO: Format this
            string make = Concierge.GetVehicleDescription().Make.ToString();
            string model = Concierge.GetVehicleDescription().Model.ToString();
            string body = Concierge.GetVehicleDescription().Body.ToString();
            string mileage = Concierge.GetVehicleDescription().Mileage.ToString(); // TODO: Format this

            const string DETAIL_UNKNOWN_MSG = "Unknown";
            if (IsUnknown(year)) year = DETAIL_UNKNOWN_MSG;
            if (IsUnknown(make)) make = DETAIL_UNKNOWN_MSG;
            if (IsUnknown(model)) model = DETAIL_UNKNOWN_MSG;
            if (IsUnknown(body)) body = DETAIL_UNKNOWN_MSG;
            if (IsUnknown(mileage)) mileage = DETAIL_UNKNOWN_MSG;

            // Comma-format mileage
            var mileageNumeric = int.Parse(mileage);
            var mileageFormatted = string.Format("{0:n0}", mileageNumeric);

            VehicleDescription.Text = $"{vin}\n\n{year} {make} {model} {body}\n\n{mileageFormatted} miles";
        }

        private bool IsUnknown(string vehicleDetail)
        {
            return string.IsNullOrEmpty(vehicleDetail) || string.IsNullOrWhiteSpace(vehicleDetail);
        }

        private void AssignLaneLot_Shown(object sender, EventArgs e)
        {
            Concierge.CheckForExistingLotAssignment(
                Concierge.VIN,
                responseIfFound: AlertExistingLotAssignment,
                responseIfFoundDifferentSeller: AlertExistingLotAssignmentDifferentSeller);
        }

        private void AlertExistingLotAssignment(string vin, LaneLotNumber lotNumber)
        {
            DialogResult userResponse =
                MessageBox.Show(
                    $"VIN: {vin}\nLot Number: {lotNumber.Number}\n\nWould you like to use it?",
                    "Existing Reservation Located.",
                    MessageBoxButtons.YesNo);

            if (userResponse == DialogResult.Yes)
            {
                ConcludeLotAssignmentSession(lotNumber);
            }
            else if (userResponse == DialogResult.No)
            {
                CancelLotAssignmentSession();
            }
        }

        private void AlertExistingLotAssignmentDifferentSeller(string vin, LaneLotNumber lotNumber, Seller seller)
        {
            MessageBox.Show(
                $"VIN: {vin}\nLot Number: {lotNumber.Number}\nSeller: {seller.Name}",
                "VIN Reservation exists with different Seller – contact office.",
                MessageBoxButtons.OK);

            CancelLotAssignmentSession();
        }

        private void OnSearchOpenReservations(object sender, EventArgs e)
        {
            // If there are any previous options in the UI's Open Reservations List
            if (OpenReservationsList.Controls.Count > 0)
            {
                // Remove them.
                OpenReservationsList.Controls.Clear();
            }

            Concierge.ConductOpenReservationsSearchForSeller();

            // TODO: Move this check into the business logic layer?
            if (Concierge.HasFoundOpenReservationsForSeller())
            {
                // List the open reservations as mutually exclusive options for the user.
                // TODO: The UI shouldn't need to know about the LaneLot table's structure to do this. Change these ADO.NET types to domain objects?
                const int LANE_LOT_NUMBER_COLUMN_INDEX = 6;
                const int RADIO_BTN_DEFAULT_WIDTH = 92;
                const int MSFT_RECD_TOUCH_SIZE = 26;
                const int MSFT_RECD_TOUCH_SPACING = 8;
                string laneLot;
                int x = MSFT_RECD_TOUCH_SPACING;
                int y = MSFT_RECD_TOUCH_SPACING * 2;
                foreach (DataRow reservation in Concierge.OpenReservations.Rows) // TODO: Create a consistent level of abstraction here.
                {
                    laneLot = reservation[LANE_LOT_NUMBER_COLUMN_INDEX].ToString();
                    var option = new RadioButton()
                    {
                        Text = laneLot,
                        Location = new Point(x, y),
                        Size = new Size(RADIO_BTN_DEFAULT_WIDTH, MSFT_RECD_TOUCH_SIZE),
                        Padding = new Padding(0, 2, 0, 2),
                        Font = new Font("Verdana", 12F)
                    };
                    option.Click += OnReservationSelected;
                    OpenReservationsList.Controls.Add(option);

                    y += (MSFT_RECD_TOUCH_SIZE + MSFT_RECD_TOUCH_SPACING); // Move the position for the next option below the one we just created.
                }

                ChangeState_OpenReservationsFound();
            }
            else
            {
                ChangeState_OpenReservationsNotFound();
            }
        }

        private void OnReservationSelected(object sender, EventArgs e)
        {
            ChangeState_ReservationSelected();
        }

        private void OnConfirmReservation(object sender, EventArgs e)
        {
            // Determine which reservation the user wants to confirm.
            RadioButton selected = OpenReservationsList.Controls.OfType<RadioButton>().First(rb => rb.Checked);
            string selectedLaneLot = selected.Text;

            // TODO: Move all of the code below into the business logic layer. The UI client shouldn't have to perform this.

            if (Concierge.ReservationStillOpen(selectedLaneLot))
            {
                ConcludeLotAssignmentSession(new LaneLotNumber(selectedLaneLot));
            }
            else
            {
                ChangeState_ReservationNotAvailable();
            }
        }

        private void ConcludeLotAssignmentSession(LaneLotNumber selectedLaneLot)
        {
            AssignmentResult result = Concierge.Confirmation(selectedLaneLot.Number);
            ResultDeliveryMethod(result, this);
            Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            CancelLotAssignmentSession();
        }

        private void CancelLotAssignmentSession()
        {
            AssignmentResult result = Concierge.Cancellation();
            ResultDeliveryMethod(result, this);
            Close();
        }

        private void OnViewSellerLineup(object sender, EventArgs e)
        {
            // If there are any previous items in the UI's Seller Lineup List
            if (SellerLineup.Items.Count > 0)
            {
                // Remove them.
                SellerLineup.Items.Clear();
            }

            SellerLineup lineup = Concierge.GetSellerLineup();

            string laneLotNumber = "";
            string vin = "";
            short year = 0;
            string make = "";
            string model = "";
            ListViewItem item;
            lineup.ForEachLot(l =>
            {
                laneLotNumber = l.LaneLotNumber.Number;
                vin = l.Vehicle.VIN;
                year = l.Vehicle.Year;
                make = l.Vehicle.Make;
                model = l.Vehicle.Model;

                item = new ListViewItem()
                {
                    Text = $"{laneLotNumber} - {vin,-17} - {year}  {make}  {model}",
                    Font = new Font("Verdana", 12F)
                };
                SellerLineup.Items.Add(item);
            });

            SellerLineup.Show();
        }

        private void ChangeState_OpenReservationsFound()
        {
            SearchOpenReservations.Show();
            OpenReservationsList.Show();
            ConfirmReservation.Hide();
            NoOpenReservationsMessage.Hide();
            ReservationNotAvailable.Hide();
        }

        private void ChangeState_OpenReservationsNotFound() 
        {
            SearchOpenReservations.Show();
            OpenReservationsList.Hide();
            ConfirmReservation.Hide();
            NoOpenReservationsMessage.Show();
            ReservationNotAvailable.Hide();
        }

        private void ChangeState_ReservationSelected() 
        {
            SearchOpenReservations.Show();
            OpenReservationsList.Show();
            ConfirmReservation.Show();
            NoOpenReservationsMessage.Hide();
            ReservationNotAvailable.Hide();
        }

        private void ChangeState_ReservationNotAvailable() 
        {
            SearchOpenReservations.Show();
            OpenReservationsList.Hide();
            ConfirmReservation.Hide();
            NoOpenReservationsMessage.Hide();
            ReservationNotAvailable.Show();
        }

        private void OnPaintFullScreenPanel(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                FullScreenPanel.ClientRectangle,
                Color.SteelBlue, 5, ButtonBorderStyle.Solid,
                Color.SteelBlue, 5, ButtonBorderStyle.Solid,
                Color.SteelBlue, 5, ButtonBorderStyle.Solid,
                Color.SteelBlue, 5, ButtonBorderStyle.Solid);
        }
    }
}

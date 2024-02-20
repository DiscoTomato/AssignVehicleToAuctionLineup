using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssignLaneLot_DataAccess;

namespace AssignLaneLot_BusinessLogic
{
    public class StockInVehicleDescription : VehicleDescription
    {
        public override object Year { get { return VehicleRecord[StockInColumn.Year]; } }
        public override object Make { get { return VehicleRecord[StockInColumn.Make]; } }
        public override object Model { get { return VehicleRecord[StockInColumn.Model]; } }
        public override object Trim { get { return VehicleRecord[StockInColumn.Trim]; } }
        public override object Body { get { return VehicleRecord[StockInColumn.Body]; } }
        public override object Mileage { get { return VehicleRecord[StockInColumn.Mileage]; } }


        public StockInVehicleDescription(DataRow vehicleStockInRecord) : base(vehicleStockInRecord)
        {
        }
    }
}
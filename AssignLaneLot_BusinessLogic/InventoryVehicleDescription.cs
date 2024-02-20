using System.Data;

using AssignLaneLot_DataAccess;

namespace AssignLaneLot_BusinessLogic
{
    internal class InventoryVehicleDescription : VehicleDescription
    {
        public override object Year { get { return VehicleRecord[InventoryColumn.Year]; } }
        public override object Make { get { return VehicleRecord[InventoryColumn.Make]; } }
        public override object Model { get { return VehicleRecord[InventoryColumn.Model]; } }
        public override object Trim { get { return VehicleRecord[InventoryColumn.Trim]; } }
        public override object Body { get { return VehicleRecord[InventoryColumn.Body]; } }
        public override object Mileage { get { return VehicleRecord[InventoryColumn.Mileage]; } }


        public InventoryVehicleDescription(DataRow vehicleInventoryRecord) : base(vehicleInventoryRecord)
        {
        }
    }
}
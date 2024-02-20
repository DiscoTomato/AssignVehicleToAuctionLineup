using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssignLaneLot_DataAccess;

namespace AssignLaneLot_BusinessLogic
{
    public abstract class VehicleDescription
    {
        public abstract object Year { get; }
        public abstract object Make { get; }
        public abstract object Model { get; }
        public abstract object Trim { get; }
        public abstract object Body { get; }
        public abstract object Mileage { get; }

        protected readonly DataRow VehicleRecord;


        public VehicleDescription(DataRow vehicleRecord)
        {
            VehicleRecord = vehicleRecord;
        }
    }
}

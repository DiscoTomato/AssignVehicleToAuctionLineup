using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_BusinessLogic
{
    public class AssignedLot
    {
        public DateTime Sale { get; }
        public Seller Seller { get; }
        public LaneLotNumber LaneLotNumber { get; }
        public Vehicle Vehicle { get; }


        internal AssignedLot(DateTime sale, Seller seller, LaneLotNumber number, Vehicle vehicle)
        {
            Sale = sale;
            Seller = seller;
            LaneLotNumber = number;
            Vehicle = vehicle;
        }
    }
}

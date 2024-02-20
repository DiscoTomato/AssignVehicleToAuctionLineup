using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_BusinessLogic
{
    public class AssignmentResult
    {
        public string VIN { get; private set; }
        public string SellerID { get; private set; }
        public string SellerName { get; private set; }
        public string LaneLot { get; private set; }
        public string Status { get; private set; }

        public AssignmentResult(string vin, string sellerId, string sellerName, string laneLot, string status)
        {
            VIN = vin;
            SellerID = sellerId;
            SellerName = sellerName;
            LaneLot = laneLot;
            Status = status;
        }
    }
}

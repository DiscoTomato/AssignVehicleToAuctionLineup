using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_BusinessLogic
{
    public class Seller
    {
        public string ID { get; }
        public string Name { get; }

        
        internal Seller(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

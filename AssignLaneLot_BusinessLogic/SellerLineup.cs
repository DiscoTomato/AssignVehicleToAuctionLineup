using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_BusinessLogic
{
    public class SellerLineup
    {
        private readonly ICollection<AssignedLot> Assignments = new List<AssignedLot>();


        public void ForEachLot(Action<AssignedLot> action)
        {
            foreach (var a in Assignments)
            {
                action(a);
            }
        }

        internal void Add(AssignedLot reservation)
        {
            Assignments.Add(reservation);
        }
    }
}
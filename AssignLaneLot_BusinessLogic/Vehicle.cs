using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_BusinessLogic
{
    public class Vehicle
    {
        public string VIN { get; }
        public short Year { get; }
        public string Make { get; }
        public string Model { get; }
        public string Trim { get; }
        public string Body { get; }
        public int Mileage { get; }

        internal Vehicle(string vin, short year, string make, string model, string trim, string body, int mileage)
        {
            VIN = vin;
            Year = year;
            Make = make;
            Model = model;
            Trim = trim;
            Body = body;
            Mileage = mileage;
        }
    }
}

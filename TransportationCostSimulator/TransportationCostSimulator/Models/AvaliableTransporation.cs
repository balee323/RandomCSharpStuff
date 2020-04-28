using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCostSimulator.Models
{
    class AllTransporation
    {

        public static List<Transportation> AvaliableTransporation { get; set; } = new List<Transportation>
        {
            new Transportation{TransporationType = "Car", CostPerKm = 0.50m},
            new Transportation{TransporationType = "Uber", CostPerKm = 3.50m},
            new Transportation{TransporationType = "Bus", CostPerKm = 0.40m},
            new Transportation{TransporationType = "Bike", CostPerKm = 0.01m},
            new Transportation{TransporationType = "Taxi", CostPerKm = 6.00m}
        };

    }
}

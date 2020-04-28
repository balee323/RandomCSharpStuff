using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCostSimulator.Models
{
    class Transportation
    {
        public string TransporationType { get; set; }

        public Decimal CostPerKm { get; set; } = 0;

    }
}

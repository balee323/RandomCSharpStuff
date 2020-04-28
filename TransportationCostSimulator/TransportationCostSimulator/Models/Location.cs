using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCostSimulator.Models
{
    class Location
    {
        public string LocationName { get; set; }
        public Point LocationCoordinates { get; set; }
        public decimal CostToDestination { get; set; } = 0;

    }
}

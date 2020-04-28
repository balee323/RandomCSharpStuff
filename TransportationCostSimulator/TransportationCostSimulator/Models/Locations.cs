using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportationCostSimulator.Models
{
    class Locations
    {

        public static List<Location> MapLocations { get; set; } = new List<Location>
        {
            new Location{LocationName = "Airport", LocationCoordinates = new Point(722, 49)},
            new Location{LocationName = "Manpyeong", LocationCoordinates = new Point(245, 81)},
            new Location{LocationName = "Banwoldang", LocationCoordinates = new Point(467, 270)},
            new Location{LocationName = "Duryu Park", LocationCoordinates =new Point(263, 370)},
            new Location{LocationName = "Seomun Market", LocationCoordinates = new Point(383, 219)}
        };


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    public class WetnessSensor : ISensor
    {
        private Location location;

        public WetnessSensor(Location l)
        {
            location.x = l.x;
            location.y = l.y;
        }

        public double returnValue()
        {
            return Environment.getWetness(location.x, location.y);
        }
    }
}

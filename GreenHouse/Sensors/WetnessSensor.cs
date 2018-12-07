using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class WetnessSensor : ISensor
    {
        private Location location;

        public WetnessSensor(int x, int y)
        {
            location.x = x;
            location.y = y;
        }

        public double returnValue()
        {
            return Environment.getWetness(location.x, location.y);
        }
    }
}

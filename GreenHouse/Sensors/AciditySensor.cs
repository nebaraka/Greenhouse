using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class AciditySensor : ISensor
    {
        private Location location;

        public AciditySensor(Location l)
        {
            location.x = l.x;
            location.y = l.y;
        }

        public double returnValue()
        {
            return Environment.getAcididty(location.x, location.y);
        }
    }
}

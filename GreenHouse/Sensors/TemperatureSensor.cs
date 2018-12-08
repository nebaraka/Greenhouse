using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class TemperatureSensor : ISensor
    {
        private Location location;

        public TemperatureSensor(Location l)
        {
            location.x = l.x;
            location.y = l.y;
        }

        public double returnValue()
        {
            return Environment.getTemperature(location.x, location.y);
        }
    }
}

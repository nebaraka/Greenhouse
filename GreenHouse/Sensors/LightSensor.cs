using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class LightSensor : ISensor
    {
        private Location location;

        public LightSensor(int x, int y)
        {
            location.x = x;
            location.y = y;
        }

        public double returnValue()
        {
            return Environment.getLight(location.x, location.y);
        }
    }
}

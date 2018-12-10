using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    public class TemperatureSensor : ISensor
    {
        private Location location;
        Environment e;

        public TemperatureSensor(Location l, Environment e)
        {
            location.x = l.x;
            location.y = l.y;
            this.e = e;
        }

        public double returnValue()
        {
            return e.getTemperature(location.x, location.y);
        }

        public override string ToString()
        {
            return "Temperature sensor";
        }
    }
}

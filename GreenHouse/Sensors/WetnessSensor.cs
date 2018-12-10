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
        Environment e;

        public WetnessSensor(Location l, Environment e)
        {
            location.x = l.x;
            location.y = l.y;
            this.e = e;
        }

        public double returnValue()
        {
            return e.getWetness(location.x, location.y);
        }

        public override string ToString()
        {
            return "Wetness sensor";
        }
    }
}

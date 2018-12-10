using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    public class AciditySensor : ISensor
    {
        private Location location;
        Environment e;

        public AciditySensor(Location l, Environment e)
        {
            location.x = l.x;
            location.y = l.y;
            this.e = e;
        }

        public double returnValue()
        {
            return e.getAcididty(location.x, location.y);
        }

        public override string ToString()
        {
            return "Acidity sensor";
        }
    }
}

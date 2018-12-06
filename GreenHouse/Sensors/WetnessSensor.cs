using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class WetnessSensor : ISensor
    {
        private int x, y;

        public WetnessSensor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double returnValue()
        {
            return Environment.getWetness(x, y);
        }
    }
}

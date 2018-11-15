using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Sensors
{
    class TemperatureSensor : ISensor
    {
        private int x, y;

        public TemperatureSensor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double returnValue()
        {
            return Environment.getTemperature(x, y);
        }

        public int getX() { return x; }
        public int getY() { return y; }
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Regulators
{
    class LightRegulator : IRegulator
    {
        private int x, y;
        private bool status;
        private double maxPower;

        public LightRegulator(int x, int y, double maxPower)
        {
            this.x = x;
            this.y = y;
            this.maxPower = maxPower;
            turnOff();
        }

        public void turnOn()
        {
            this.status = true;
        }
        public void turnOff()
        {
            this.status = false;
        }

        private void work(double currentPower)
        {
            double[] result = new double[3];
            result[0] = (double)x;
            result[1] = (double)y;
            if (this.status == true)
            {
                result[2] = (double)maxPower;
            }
            else
            {
                result[2] = 0.0;
            }
            Environment.lightRegValues.Add(result);
        }

        public int getX() { return x; }
        public int getY() { return y; }
        public double getMaxPower() { return maxPower; }
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }
        public void setMaxPower(double maxPower) { this.maxPower = maxPower; }
        public bool isActive() { return status; }
    }
}

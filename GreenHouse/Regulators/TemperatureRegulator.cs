﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Regulators
{
    class TemperatureRegulator : IRegulator
    {
        private Location location;
        private bool status;
        private double maxPower;

        public TemperatureRegulator(Location l, double maxPower)
        {
            location.x = l.x;
            location.y = l.y;
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

        private void work(double currentPower) //This implementation MUST be changed
        {
            double[] result = new double[3];
            result[0] = (double)location.x;
            result[1] = (double)location.y;
            if (this.status == true)
            {
                result[2] = (double)maxPower;
            }
            else
            {
                result[2] = 0.0;
            }
            Environment.temperatureRegValues.Add(result);
        }
        public double getMaxPower() { return maxPower; }
        public void setMaxPower(double maxPower) { this.maxPower = maxPower; }
        public bool isActive() { return status; }
    }
}

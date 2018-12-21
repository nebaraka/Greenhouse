﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Regulators
{
    public class WetnessRegulator : IRegulator
    {
        private Location location;
        private bool status;
        private double maxPower;
        private Environment e;

        public WetnessRegulator(Location l, double maxPower, Environment e)
        {
            location.x = l.x;
            location.y = l.y;
            this.maxPower = maxPower;
            turnOff();
            this.e = e;
        }

        public void turnOn()
        {
            this.status = true;
        }
        public void turnOff()
        {
            this.status = false;
        }

        public void work(double currentPower)
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
            e.wetnessRegValues.Add(result);
        }

        public double getMaxPower() { return maxPower; }
        public void setMaxPower(double maxPower) { this.maxPower = maxPower; }
        public bool isActive() { return status; }

        public override string ToString()
        {
            return "Wetness regulator";
        }
    }
}

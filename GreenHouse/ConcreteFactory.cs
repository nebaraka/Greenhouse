using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    class ConcreteFactory
    {
        public IRegulator createRegulator()
        {
            return new TemperatureRegulator(0, 0, 0);
        }

        public ISensor createSensor()
        {
            return new TemperatureSensor(0, 0);
        }
    }
}

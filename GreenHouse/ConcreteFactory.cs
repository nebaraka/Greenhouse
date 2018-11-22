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
        public IRegulator createAcidityRegulator(int x, int y, double power)
        {
            return new AcidityRegulator(x, y, power);
        }
        public IRegulator createLightRegulator(int x, int y, double power)
        {
            return new LightRegulator(x, y, power);
        }
        public IRegulator createTemperatureRegulator(int x, int y, double power)
        {
            return new TemperatureRegulator(x, y, power);
        }
        public IRegulator createWetnessRegulator(int x, int y, double power)
        {
            return new WetnessRegulator(x, y, power);
        }

        public ISensor createAciditySensor(int x, int y)
        {
            return new AciditySensor(x, y);
        }
        public ISensor createLightSensor(int x, int y)
        {
            return new LightSensor(x, y);
        }
        public ISensor createTemperatureSensor(int x, int y)
        {
            return new TemperatureSensor(x, y);
        }
        public ISensor createWetnessSensor(int x, int y)
        {
            return new WetnessSensor(x, y);
        }
    }
}

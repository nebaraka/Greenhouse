using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    public class ConcreteFactory : IFactory
    {
        public IRegulator createAcidityRegulator(Location l, double power)
        {
            return new AcidityRegulator(l, power);
        }
        public IRegulator createLightRegulator(Location l, double power)
        {
            return new LightRegulator(l, power);
        }
        public IRegulator createTemperatureRegulator(Location l, double power)
        {
            return new TemperatureRegulator(l, power);
        }
        public IRegulator createWetnessRegulator(Location l, double power)
        {
            return new WetnessRegulator(l, power);
        }

        public ISensor createAciditySensor(Location l)
        {
            return new AciditySensor(l);
        }
        public ISensor createLightSensor(Location l)
        {
            return new LightSensor(l);
        }
        public ISensor createTemperatureSensor(Location l)
        {
            return new TemperatureSensor(l);
        }
        public ISensor createWetnessSensor(Location l)
        {
            return new WetnessSensor(l);
        }
    }
}

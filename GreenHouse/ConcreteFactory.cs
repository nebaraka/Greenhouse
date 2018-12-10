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
        public IRegulator createAcidityRegulator(Location l, double power, Environment e)
        {
            return new AcidityRegulator(l, power, e);
        }
        public IRegulator createLightRegulator(Location l, double power, Environment e)
        {
            return new LightRegulator(l, power, e);
        }
        public IRegulator createTemperatureRegulator(Location l, double power, Environment e)
        {
            return new TemperatureRegulator(l, power, e);
        }
        public IRegulator createWetnessRegulator(Location l, double power, Environment e)
        {
            return new WetnessRegulator(l, power, e);
        }

        public ISensor createAciditySensor(Location l, Environment e)
        {
            return new AciditySensor(l, e);
        }
        public ISensor createLightSensor(Location l, Environment e)
        {
            return new LightSensor(l, e);
        }
        public ISensor createTemperatureSensor(Location l, Environment e)
        {
            return new TemperatureSensor(l, e);
        }
        public ISensor createWetnessSensor(Location l, Environment e)
        {
            return new WetnessSensor(l, e);
        }
    }
}

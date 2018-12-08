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
        public static IRegulator createAcidityRegulator(Location l, double power)
        {
            return new AcidityRegulator(l, power);
        }
        public static IRegulator createLightRegulator(Location l, double power)
        {
            return new LightRegulator(l, power);
        }
        public static IRegulator createTemperatureRegulator(Location l, double power)
        {
            return new TemperatureRegulator(l, power);
        }
        public static IRegulator createWetnessRegulator(Location l, double power)
        {
            return new WetnessRegulator(l, power);
        }

        public static ISensor createAciditySensor(Location l)
        {
            return new AciditySensor(l);
        }
        public static ISensor createLightSensor(Location l)
        {
            return new LightSensor(l);
        }
        public static ISensor createTemperatureSensor(Location l)
        {
            return new TemperatureSensor(l);
        }
        public static ISensor createWetnessSensor(Location l)
        {
            return new WetnessSensor(l);
        }
    }
}

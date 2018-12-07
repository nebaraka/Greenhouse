using GreenHouse.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.DeviceMaps
{
    static class SensorMap
    {
        public static Dictionary<Location, AciditySensor> mapOfAciditySensors;
        public static Dictionary<Location, LightSensor> mapOfLightSensors;
        public static Dictionary<Location, TemperatureSensor> mapOfTemperatureSensors;
        public static Dictionary<Location, WetnessSensor> mapOfWetnessSensors;
        static SensorMap()
        {
            mapOfAciditySensors = new Dictionary<Location, AciditySensor>();
            mapOfLightSensors = new Dictionary<Location, LightSensor>();
            mapOfTemperatureSensors = new Dictionary<Location, TemperatureSensor>();
            mapOfWetnessSensors = new Dictionary<Location, WetnessSensor>();
        }
    }
}

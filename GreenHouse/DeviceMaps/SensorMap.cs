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
        public static Dictionary<Location, ISensor> mapOfAciditySensors;
        public static Dictionary<Location, ISensor> mapOfLightSensors;
        public static Dictionary<Location, ISensor> mapOfTemperatureSensors;
        public static Dictionary<Location, ISensor> mapOfWetnessSensors;
        static SensorMap()
        {
            mapOfAciditySensors = new Dictionary<Location, ISensor>();
            mapOfLightSensors = new Dictionary<Location, ISensor>();
            mapOfTemperatureSensors = new Dictionary<Location, ISensor>();
            mapOfWetnessSensors = new Dictionary<Location, ISensor>();
        }
    }
}

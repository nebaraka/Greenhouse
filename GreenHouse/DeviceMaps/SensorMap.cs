using GreenHouse.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.DeviceMaps
{
    public class SensorMap
    {
        public Dictionary<Location, ISensor> mapOfAciditySensors;
        public Dictionary<Location, ISensor> mapOfLightSensors;
        public Dictionary<Location, ISensor> mapOfTemperatureSensors;
        public Dictionary<Location, ISensor> mapOfWetnessSensors;
        public SensorMap()
        {
            mapOfAciditySensors = new Dictionary<Location, ISensor>();
            mapOfLightSensors = new Dictionary<Location, ISensor>();
            mapOfTemperatureSensors = new Dictionary<Location, ISensor>();
            mapOfWetnessSensors = new Dictionary<Location, ISensor>();
        }
    }
}

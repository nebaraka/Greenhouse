using GreenHouse.Regulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.DeviceMaps
{
    static class RegulatorMap
    {
        public static Dictionary<Location, AcidityRegulator> mapOfAcidityRegulators;
        public static Dictionary<Location, LightRegulator> mapOfLightRegulators;
        public static Dictionary<Location, TemperatureRegulator> mapOfTemperatureRegulators;
        public static Dictionary<Location, WetnessRegulator> mapOfWetnessRegulators;
        static RegulatorMap()
        {
            mapOfAcidityRegulators = new Dictionary<Location, AcidityRegulator>();
            mapOfLightRegulators = new Dictionary<Location, LightRegulator>();
            mapOfTemperatureRegulators = new Dictionary<Location, TemperatureRegulator>();
            mapOfWetnessRegulators = new Dictionary<Location, WetnessRegulator>();
        }
    }
}

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
        public static Dictionary<Location, IRegulator> mapOfAcidityRegulators;
        public static Dictionary<Location, IRegulator> mapOfLightRegulators;
        public static Dictionary<Location, IRegulator> mapOfTemperatureRegulators;
        public static Dictionary<Location, IRegulator> mapOfWetnessRegulators;
        static RegulatorMap()
        {
            mapOfAcidityRegulators = new Dictionary<Location, IRegulator>();
            mapOfLightRegulators = new Dictionary<Location, IRegulator>();
            mapOfTemperatureRegulators = new Dictionary<Location, IRegulator>();
            mapOfWetnessRegulators = new Dictionary<Location, IRegulator>();
        }
    }
}

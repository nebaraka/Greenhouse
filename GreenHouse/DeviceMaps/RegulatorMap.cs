using GreenHouse.Regulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.DeviceMaps
{
    public class RegulatorMap
    {
        public Dictionary<Location, IRegulator> mapOfAcidityRegulators;
        public Dictionary<Location, IRegulator> mapOfLightRegulators;
        public Dictionary<Location, IRegulator> mapOfTemperatureRegulators;
        public Dictionary<Location, IRegulator> mapOfWetnessRegulators;
        public RegulatorMap()
        {
            mapOfAcidityRegulators = new Dictionary<Location, IRegulator>();
            mapOfLightRegulators = new Dictionary<Location, IRegulator>();
            mapOfTemperatureRegulators = new Dictionary<Location, IRegulator>();
            mapOfWetnessRegulators = new Dictionary<Location, IRegulator>();
        }
    }
}

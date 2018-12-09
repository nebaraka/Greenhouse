using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.DeviceMaps;

namespace GreenHouse
{
    public interface IGreenhouse
    {
        GrowthPlan currentGrowthPlan { get; set; }
        Environment currentEnvironment { get; set; }
        RegulatorMap currentRegulatorMap { get; set; }
        SensorMap currentSensorMap { get; set; }
    }
}

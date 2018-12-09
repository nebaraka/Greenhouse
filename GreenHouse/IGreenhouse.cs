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
        event Delegates.del tickInfo;
        event Delegates.del2 tickInfo2;
        Greenhouse.Controllers currentListOfControllers { get; set; }
        GrowthPlan currentGrowthPlan { get; set; }
        Environment currentEnvironment { get; set; }
        RegulatorMap currentRegulatorMap { get; set; }
        SensorMap currentSensorMap { get; set; }
        Time currentTime { get; set; }
        void simulate();
    }

    public static class Delegates
    {
        public delegate void del(int time, ParamValues.Corridor ac, ParamValues.Corridor l,
            ParamValues.Corridor temp, ParamValues.Corridor w);
        public delegate void del2(double a, double l, double t, double w);
    }
}

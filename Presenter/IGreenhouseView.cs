using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IGreenhouseView : IView
    {
        event Action addDevices;
        event Action configurePlan;
        event Action startSimulation;
        event Action showGrowthRates;
        event Action saveConfiguration;
        event Action aAlloc;
        event Action lAlloc;
        event Action tAlloc;
        event Action wAlloc;

        void setTime(int t);
        void setAcidity(string s);
        void setLight(string s);
        void setTemperature(string s);
        void setWetness(string s);
        void setRegulators();
        void setSensors();
        void drawAcidityAllocation(int x, int y, double relation);
        void drawLightAllocation(int x, int y, double relation);
        void drawTemperatureAllocation(int x, int y, double relation);
        void drawWetnessAllocation(int x, int y, double relation);
    }
}

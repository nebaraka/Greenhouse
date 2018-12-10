using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPlanConfigurationView : IView
    {
        event planDelegates.del ConfirmPlan;
        //event Action PlanConfiguration_Load;

        string GetTemperatureCorridors { get; }
        string GetTemperatureIntervals { get; }
        string GetLightCorridors { get; }
        string GetLightIntervals { get; }
        string GetAcidityCorridors { get; }
        string GetAcidityIntervals { get; }
        string GetWetnessCorridors { get; }
        string GetWetnessIntervals { get; }
        
    }
    public static class planDelegates
    {
        public delegate void del(string temperatureCorridors, string lightCorridors, string acidityCorridors,
            string wetnessCorridors, string temperatureIntervals, string lightIntervals, string acidityIntervals,
            string wetnessIntervals);
    }
}

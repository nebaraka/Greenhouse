using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPlanConfigurationView : IView
    {
        event Action ConfirmPlan;
        //event Action PlanConfiguration_Load;

        string GetTemperatureCorridors { get; }
        string GetTemperatureIntervals { get; }
        string GetLightCorridors { get; }
        string GetLightIntervals { get; }
        string GetAcidityCorridors { get; }
        string GetAcidityIntervals { get; }
        string GetWetnessCorridors { get; }
        string GetWetnessIntervals { get; }

        void show();
    }
}

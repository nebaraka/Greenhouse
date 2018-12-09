using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IGrowthRatesView : IView
    {
        void buildAcidityGraph();
        void buildLightGraph();
        void buildTemperatureGraph();
        void buildWetnessGraph();
        void showAcidity(double a);
        void showLight(double l);
        void showTemperature(double t);
        void showWetness(double w);
    }
}

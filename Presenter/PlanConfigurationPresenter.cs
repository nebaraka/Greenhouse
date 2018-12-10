using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse;

namespace Presenter
{
    public class PlanConfigurationPresenter
    {
        private IKernel _kernel;
        private IPlanConfigurationView _view;
        private IGreenhouse _model;
        public PlanConfigurationPresenter(IKernel kernel, IPlanConfigurationView view, IGreenhouse model)
        {
            _kernel = kernel;
            _view = view;
            _model = model;

            _view.ConfirmPlan += ConfirmPlan;
        }
        public void ConfirmPlan(string temperatureCorridors, string lightCorridors, string acidityCorridors,
            string wetnessCorridors, string temperatureIntervals, string lightIntervals, string acidityIntervals,
            string wetnessIntervals)
        {
            //MUST BE REWORKED
            string[] temperatureCor = temperatureCorridors.Split(';');
            string[] temperatureInts = temperatureIntervals.Split(';');
            string[] lightCor = lightCorridors.Split(';');
            string[] lightInts = lightIntervals.Split(';');
            string[] acidityCor = temperatureCorridors.Split(';');
            string[] acidityInts = temperatureIntervals.Split(';');
            string[] wetnessCor = wetnessCorridors.Split(';');
            string[] wetnessInts = wetnessIntervals.Split(';');
            ParamValues[] paramValues = new ParamValues[temperatureInts.Length];
            for (int i = 0; i < temperatureCor.Length; i++)
            {
                string[] tempVal = temperatureCor[i].Split('-');
                paramValues[i].temperature.minValue = Convert.ToDouble(tempVal[0]);
                paramValues[i].temperature.maxValue = Convert.ToDouble(tempVal[1]);
                string[] lightVal = lightCor[i].Split('-');
                paramValues[i].light.minValue = Convert.ToDouble(lightVal[0]);
                paramValues[i].light.maxValue = Convert.ToDouble(lightVal[1]);
                string[] acidityVal = acidityCor[i].Split('-');
                paramValues[i].acidity.minValue = Convert.ToDouble(acidityVal[0]);
                paramValues[i].acidity.maxValue = Convert.ToDouble(acidityVal[1]);
                string[] wetnessVal = wetnessCor[i].Split('-');
                paramValues[i].wetness.minValue = Convert.ToDouble(wetnessVal[0]);
                paramValues[i].wetness.maxValue = Convert.ToDouble(wetnessVal[1]);
                paramValues[i].timeSlice = Convert.ToInt32(temperatureInts[i]);
            }
            _model.currentGrowthPlan.Initialize(paramValues);
        }
        public void run()
        {
            _view.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using GreenHouse;

namespace Presenter
{
    public class GreenhousePresenter
    {
        private IKernel kernel;
        private IGreenhouse model;
        private IGreenhouseView view;

        public GreenhousePresenter(IKernel k, IGreenhouse g, IGreenhouseView v)
        {
            kernel = k;
            model = g;
            view = v;

            //event subscription
            view.addDevices += addDevices;
            view.configurePlan += configurePlan;
            view.startSimulation += startSimulation;
            view.showGrowthRates += showGrowthRates;
            view.saveConfiguration += saveConfiguration;
            model.tickInfo += tickUpdate;
        }

        public void addDevices()
        {
            //open AddDevices form
            kernel.Get<AddDevicesPresenter>().run();
        }

        public void configurePlan()
        {
            //open ConfigurePlan form
            kernel.Get<PlanConfigurationPresenter>().run();
        }

        public void startSimulation()
        {
            //start simulation))0
            model.simulate();
        }

        public void showGrowthRates()
        {
            //open corresponding form
            kernel.Get<GrowthRatesPresenter>().run();
        }

        public void saveConfiguration()
        {
            //open corresponding form
        }

        public void tickUpdate(int time, ParamValues.Corridor ac, ParamValues.Corridor l,
            ParamValues.Corridor temp, ParamValues.Corridor w)
        {
            view.setTime(time);
            view.setAcidity(ac.minValue.ToString() + "-" + ac.maxValue.ToString());
            view.setLight(l.minValue.ToString() + "-" + l.maxValue.ToString());
            view.setTemperature(temp.minValue.ToString() + "-" + temp.maxValue.ToString());
            view.setWetness(w.minValue.ToString() + "-" + w.maxValue.ToString());
        }

        //Allocation
        public void acidityAllocation()
        {
            //request to Greenhouse.Environment
        }

        public void lightAllocation()
        {
            //request to Greenhouse.Environment
        }

        public void temperatureAllocation()
        {
            //request to Greenhouse.Environment
        }

        public void wetnessAllocation()
        {
            //request to Greenhouse.Environment
        }

        public void run()
        {

            view.Show();
        }
    }
}

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
        }

        public void addDevices()
        {
            //open AddDevices form
            kernel.Get<AddDevicesPresenter>().run();
        }

        public void configurePlan()
        {
            //open ConfigurePlan form
        }

        public void startSimulation()
        {
            //start simulation))0
            model.simulate();
        }

        public void showGrowthRates()
        {
            //open corresponding form
        }

        public void saveConfiguration()
        {
            //open corresponding form
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

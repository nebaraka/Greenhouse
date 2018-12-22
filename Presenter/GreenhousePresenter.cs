using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using GreenHouse;
using System.Threading;
using GreenHouse.Verification;

namespace Presenter
{
    public class GreenhousePresenter
    {
        private IKernel kernel;
        private IGreenhouse model;
        private IGreenhouseView view;
        private IGreenhouseVerificationService verification;

        public GreenhousePresenter(IKernel k, IGreenhouse g, IGreenhouseView v,
            IGreenhouseVerificationService vs)
        {
            kernel = k;
            model = g;
            view = v;
            verification = vs;

            //event subscription
            view.addDevices += addDevices;
            view.configurePlan += configurePlan;
            view.startSimulation += startSimulation;
            view.showGrowthRates += showGrowthRates;
            view.saveConfiguration += saveConfiguration;
            view.aAlloc += acidityAllocation;
            view.lAlloc += lightAllocation;
            view.tAlloc += temperatureAllocation;
            view.wAlloc += wetnessAllocation;

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
            if (verification.GreenhouseVerification())
            {
                Thread thread = new Thread(model.simulate);
                thread.Start();
            }
            else
                view.ShowMessage("You have to add at least one device of each type and configure plan.");
            //model.simulate();
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
            if (verification.GreenhouseVerification())
            {
                //request to Greenhouse.Environment
                GreenHouse.Environment.Cell[,] cells = model.currentEnvironment.getCells();
                //const have to be changed
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                        view.drawAcidityAllocation(i, j,
                            cells[i, j].acidity / model.currentEnvironment.MaxAcidity());
            }
            else
                view.ShowMessage("You have to add at least one device of each type and configure plan.");
        }

        public void lightAllocation()
        {
            if (verification.GreenhouseVerification())
            {
                //request to Greenhouse.Environment
                GreenHouse.Environment.Cell[,] cells = model.currentEnvironment.getCells();
                //const have to be changed
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                        view.drawLightAllocation(i, j,
                            cells[i, j].light / model.currentEnvironment.MaxLight());
            }
            else
                view.ShowMessage("You have to add at least one device of each type and configure plan.");
        }

        public void temperatureAllocation()
        {
            if (verification.GreenhouseVerification())
            {
                //request to Greenhouse.Environment
                GreenHouse.Environment.Cell[,] cells = model.currentEnvironment.getCells();
                //const have to be changed
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                        view.drawTemperatureAllocation(i, j,
                            cells[i, j].temperature / model.currentEnvironment.MaxTemperature());
            }
            else
                view.ShowMessage("You have to add at least one device of each type and configure plan.");
        }

        public void wetnessAllocation()
        {
            if (verification.GreenhouseVerification())
            {
                //request to Greenhouse.Environment
                GreenHouse.Environment.Cell[,] cells = model.currentEnvironment.getCells();
                //const have to be changed
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                        view.drawWetnessAllocation(i, j,
                            cells[i, j].wetness / model.currentEnvironment.MaxWetness());
            }
            else
                view.ShowMessage("You have to add at least one device of each type and configure plan.");
            
        }

        public void run()
        {

            view.Show();
        }
    }
}

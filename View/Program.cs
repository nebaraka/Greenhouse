using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ninject;

using Presenter;
using GreenHouse;
using GreenHouse.Regulators;
using GreenHouse.Sensors;
using GreenHouse.Verification;

namespace View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Ninject.StandardKernel kernel = new StandardKernel();
            kernel.Bind<ApplicationContext>().ToConstant(new ApplicationContext());

            kernel.Bind<IAddDevicesView>().To<AddDevicesView>();
            kernel.Bind<IGreenhouseView>().To<GreenhouseView>();
            kernel.Bind<IGrowthRatesView>().To<GrowthRatesView>();
            kernel.Bind<IPlanConfigurationView>().To<PlanConfigurationView>();

            kernel.Bind<IAddDevicesVerificationService>().To<AddDevicesVerificationService>();
            kernel.Bind<IPlanConfigurationVerificationService>().To<PlanConfigurationVerificationService>();
            kernel.Bind<IGreenhouseVerificationService>().To<GreenhouseVerificationService>();

            kernel.Bind<AddDevicesPresenter>().ToSelf();
            kernel.Bind<GreenhousePresenter>().ToSelf();
            kernel.Bind<GrowthRatesPresenter>().ToSelf();
            kernel.Bind<PlanConfigurationPresenter>().ToSelf();

            kernel.Bind<IGreenhouse>().To<Greenhouse>().InSingletonScope();
            kernel.Bind<IGrowthPlan>().To<GrowthPlan>().InSingletonScope();
            kernel.Bind<IFactory>().To<ConcreteFactory>().InSingletonScope();

            kernel.Bind<IRegulator>().To<AcidityRegulator>().InSingletonScope();
            kernel.Bind<IRegulator>().To<LightRegulator>().InSingletonScope();
            kernel.Bind<IRegulator>().To<TemperatureRegulator>().InSingletonScope();
            kernel.Bind<IRegulator>().To<WetnessRegulator>().InSingletonScope();

            kernel.Bind<ISensor>().To<AciditySensor>().InSingletonScope();
            kernel.Bind<ISensor>().To<LightSensor>().InSingletonScope();
            kernel.Bind<ISensor>().To<TemperatureSensor>().InSingletonScope();
            kernel.Bind<ISensor>().To<WetnessSensor>().InSingletonScope();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            kernel.Get<GreenhousePresenter>().run();
            Application.Run(kernel.Get<ApplicationContext>());
        }
    }
}

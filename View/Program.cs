using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ninject;

using Presenter;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //kernel.Get<GreenhousePresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }
    }
}

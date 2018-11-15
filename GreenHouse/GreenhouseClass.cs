using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse
{
    static class GreenhouseClass
    {
        static List<IController> listOfControllers;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Greenhouse());
        }

        static void initialize() { }
        static void simulate() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenHouse.Controllers;

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

        static void initialize(/*Params from GUI init*/)//I really don`t know what numbers paste
        {
            listOfControllers.Add(new AcidityController(1, 1));
            listOfControllers.Add(new LightController(1, 1));
            listOfControllers.Add(new TemperatureController(1, 1));
            listOfControllers.Add(new WetnessController(1, 1));
            //Init cycle??
        }
        static void simulate()
        {
            while(true)//Control cycle
            {
               foreach(IController c in listOfControllers)
                {
                    c.askSensors();
                    c.calculate();
                    c.setRegulators();
                }
                Environment.recount();
            }
        }
    }
}

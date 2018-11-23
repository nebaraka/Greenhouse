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
        public static void set(List<IController> controllers)
        {
            listOfControllers = controllers;
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
                //graphs
            }
        }
    }
}

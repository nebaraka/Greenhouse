using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenHouse.Controllers;
using GreenHouse.DeviceMaps;

namespace GreenHouse
{
    public class Greenhouse : IGreenhouse
    {
        private struct Controllers
        {
            public AcidityController ac;
            public LightController lc;
            public TemperatureController tc;
            public WetnessController wc;
        }
        private Controllers listOfControllers;
        private GrowthPlan gp;
        private Environment e;
        private RegulatorMap rm;
        private SensorMap sm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    //Application.Run(new Greenhouse());
        //}
        public Greenhouse()
        {
            listOfControllers = new Controllers();
            gp = new GrowthPlan();
            e = new Environment();
            rm = new RegulatorMap();
            sm = new SensorMap();
        }

        public GrowthPlan currentGrowthPlan
        {
            get { return gp; }
            set { gp = value; }
        }
        public Environment currentEnvironment
        {
            get { return e; }
            set {e = value; }
        }
        public RegulatorMap currentRegulatorMap
        {
            get { return rm; }
            set { rm = value; }
        }
        public SensorMap currentSensorMap
        {
            get { return sm; }
            set { sm = value; }
        }

        public bool isAnyNull()
        {
            if (listOfControllers.ac == null || listOfControllers.lc == null ||
                listOfControllers.tc == null || listOfControllers.wc == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void set(AcidityController ac, LightController lc, TemperatureController tc, WetnessController wc)
        {
            listOfControllers.ac = ac;
            listOfControllers.lc = lc;
            listOfControllers.tc = tc;
            listOfControllers.wc = wc;
            //Init cycle??
        }
        public void simulate()
        {
            while(true)//Control cycle
            {
                listOfControllers.ac.askSensors();
                listOfControllers.ac.calculate();
                listOfControllers.ac.setRegulators();

                listOfControllers.lc.askSensors();
                listOfControllers.lc.calculate();
                listOfControllers.lc.setRegulators();

                listOfControllers.tc.askSensors();
                listOfControllers.tc.calculate();
                listOfControllers.tc.setRegulators();

                listOfControllers.wc.askSensors();
                listOfControllers.wc.calculate();
                listOfControllers.wc.setRegulators();
                Environment.recount();
                //graphs
            }
        }
    }
}

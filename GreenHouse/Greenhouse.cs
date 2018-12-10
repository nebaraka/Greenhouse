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
        public struct Controllers
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
        private Time time;

        public event Delegates.del tickInfo;
        public event Delegates.del2 tickInfo2;
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
            time = new Time();
            gp = new GrowthPlan(time);
            e = new Environment();
            rm = new RegulatorMap();
            sm = new SensorMap();
            listOfControllers = new Controllers();
            listOfControllers.ac = new AcidityController(rm, sm, gp);
            listOfControllers.lc = new LightController(rm, sm, gp);
            listOfControllers.tc = new TemperatureController(rm, sm, gp);
            listOfControllers.wc = new WetnessController(rm, sm, gp);
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
        public Controllers currentListOfControllers
        {
            get { return listOfControllers; }
            set { listOfControllers = value; }
        }
        public Time currentTime
        {
            get { return time; }
            set { time = value; }
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
                e.recount();

                time.Tick();
                if (time.GetTime() > 100) break;

                tickInfo?.Invoke(time.GetTime(), gp.getAcidity(), gp.getLight(),
                     gp.getTemperature(), gp.getWetness());
                tickInfo2?.Invoke(0, 0, 0, 0);//HERE MUST BE AVERAGE MEANINGS

                //graphs
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse.Controllers
{
    class WetnessController : IController
    {
        private bool[] commandValues;
        private double[] recievedValues;
        private List<WetnessRegulator> listOfRegulators;
        private List<WetnessSensor> listOfSensors;

        public WetnessController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            listOfRegulators = new List<WetnessRegulator>(regulatorsAmount);
            listOfSensors = new List<WetnessSensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r)
        {
            listOfRegulators.Add((WetnessRegulator)r);
        }
        public void addSensor(ISensor s)
        {
            listOfSensors.Add((WetnessSensor)s);
        }
        public void deleteRegulator(string[] strs)
        {
            //TODO
        }
        public void deleteSensor(string[] strs)
        {
            //TODO
        }
        public void askSensors()
        {
            int i = 0;//Counter
            foreach (WetnessSensor sensor in listOfSensors)
            {
                recievedValues[i] = sensor.returnValue();
                i++;
            }
        }
        public void calculate()
        {

        }
        public void setRegulators()
        {

        }
    }
}

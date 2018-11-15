using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse.Controllers
{
    class AcidityController : IController
    {
        private bool[] commandValues;
        private double[] recievedValues;
        private List<AcidityRegulator> listOfRegulators;
        private List<AciditySensor> listOfSensors;

        public AcidityController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            listOfRegulators = new List<AcidityRegulator>(regulatorsAmount);
            listOfSensors = new List<AciditySensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r)
        {
            listOfRegulators.Add((AcidityRegulator)r);
        }
        public void addSensor(ISensor s)
        {
            listOfSensors.Add((AciditySensor)s);
        }
        public void askSensors()
        {

        }
        public void calculate()
        {

        }
        public void setRegulators()
        {

        }
    }
}

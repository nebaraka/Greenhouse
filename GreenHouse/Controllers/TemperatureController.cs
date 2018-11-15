using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    class TemperatureController : IController
    {
        private bool[] commandValues;
        private double[] recievedValues;
        private List<TemperatureRegulator> listOfRegulators;
        private List<TemperatureSensor> listOfSensors;

        public TemperatureController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            listOfRegulators = new List<TemperatureRegulator>(regulatorsAmount);
            listOfSensors = new List<TemperatureSensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r)
        {
            listOfRegulators.Add((TemperatureRegulator)r);
        }
        public void addSensor(ISensor s)
        {
            listOfSensors.Add((TemperatureSensor)s);
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

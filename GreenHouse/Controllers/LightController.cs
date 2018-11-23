﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse.Controllers
{
    class LightController : IController
    {
        private bool[] commandValues;
        private double[] recievedValues;
        private List<LightRegulator> listOfRegulators;
        private List<LightSensor> listOfSensors;

        public LightController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            listOfRegulators = new List<LightRegulator>(regulatorsAmount);
            listOfSensors = new List<LightSensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r)
        {
            listOfRegulators.Add((LightRegulator)r);
        }
        public void addSensor(ISensor s)
        {
            listOfSensors.Add((LightSensor)s);
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
            foreach (LightSensor sensor in listOfSensors)
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

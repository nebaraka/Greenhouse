using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    interface IController
    {
        void addRegulator(IRegulator r);
        void addSensor(ISensor s);
        void deleteRegulator(string[] strs);
        void deleteSensor(string[] strs);
        void askSensors();
        void calculate();
        void setRegulators();
    }
}

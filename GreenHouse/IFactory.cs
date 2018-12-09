using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    public interface IFactory
    {
        IRegulator createAcidityRegulator(Location l, double power);
        IRegulator createLightRegulator(Location l, double power);
        IRegulator createTemperatureRegulator(Location l, double power);
        IRegulator createWetnessRegulator(Location l, double power);

        ISensor createAciditySensor(Location l);
        ISensor createLightSensor(Location l);
        ISensor createTemperatureSensor(Location l);
        ISensor createWetnessSensor(Location l);
    }
}

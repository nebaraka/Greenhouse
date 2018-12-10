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
        IRegulator createAcidityRegulator(Location l, double power, Environment e);
        IRegulator createLightRegulator(Location l, double power, Environment e);
        IRegulator createTemperatureRegulator(Location l, double power, Environment e);
        IRegulator createWetnessRegulator(Location l, double power, Environment e);

        ISensor createAciditySensor(Location l, Environment e);
        ISensor createLightSensor(Location l, Environment e);
        ISensor createTemperatureSensor(Location l, Environment e);
        ISensor createWetnessSensor(Location l, Environment e);
    }
}

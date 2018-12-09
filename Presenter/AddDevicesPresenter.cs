using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.DeviceMaps;
using GreenHouse.Sensors;
using GreenHouse.Regulators;
using GreenHouse;


namespace Presenter
{
    public class AddDevicesPresenter
    {
        public static void addAcidityRegulator(Location l, double power)
        {
            RegulatorMap.mapOfAcidityRegulators.Add(l, ConcreteFactory.createAcidityRegulator(l, power));
        }
        public static void addLightRegulator(Location l, double power)
        {
            RegulatorMap.mapOfLightRegulators.Add(l, ConcreteFactory.createLightRegulator(l, power));
        }
        public static void addTemperatureRegulator(Location l, double power)
        {
            RegulatorMap.mapOfTemperatureRegulators.Add(l, ConcreteFactory.createTemperatureRegulator(l, power));
        }
        public static void addWetnessRegulator(Location l, double power)
        {
            RegulatorMap.mapOfWetnessRegulators.Add(l, ConcreteFactory.createWetnessRegulator(l, power));
        }

        public static void deleteAcidityRegulator(Location l)
        {
            RegulatorMap.mapOfAcidityRegulators.Remove(l);
        }
        public static void deleteLightRegulator(Location l)
        {
            RegulatorMap.mapOfLightRegulators.Remove(l);
        }
        public static void deleteTemperatureRegulator(Location l)
        {
            RegulatorMap.mapOfTemperatureRegulators.Remove(l);
        }
        public static void deleteWetnessRegulator(Location l)
        {
            RegulatorMap.mapOfWetnessRegulators.Remove(l);
        }


        public static void addAciditySensor(Location l)
        {
            SensorMap.mapOfAciditySensors.Add(l, ConcreteFactory.createAciditySensor(l));
        }
        public static void addLightSensor(Location l)
        {
            SensorMap.mapOfLightSensors.Add(l, ConcreteFactory.createLightSensor(l));
        }
        public static void addTemperatureSensor(Location l)
        {
            SensorMap.mapOfTemperatureSensors.Add(l, ConcreteFactory.createTemperatureSensor(l));
        }
        public static void addWetnessSensor(Location l)
        {
            SensorMap.mapOfWetnessSensors.Add(l, ConcreteFactory.createWetnessSensor(l));
        }

        public static void deleteAciditySensor(Location l)
        {
            SensorMap.mapOfAciditySensors.Remove(l);
        }
        public static void deleteLightSensor(Location l)
        {
            SensorMap.mapOfLightSensors.Remove(l);
        }
        public static void deleteTemperatureSensor(Location l)
        {
            SensorMap.mapOfTemperatureSensors.Remove(l);
        }
        public static void deleteWetnessSensor(Location l)
        {
            SensorMap.mapOfWetnessSensors.Remove(l);
        }
    }
}

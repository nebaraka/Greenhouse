using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using GreenHouse.DeviceMaps;
using GreenHouse.Sensors;
using GreenHouse.Regulators;
using GreenHouse;


namespace Presenter
{
    public class AddDevicesPresenter
    {
        public const double ACIDITY_MAX_POWER = 12;
        public const double LIGHT_MAX_POWER = 35;
        public const double TEMPERATURE_MAX_POWER = 120;
        public const double WETNESS_MAX_POWER = 100;

        private IKernel kernel;
        private IGreenhouse model;
        private IAddDevicesView view;

        AddDevicesPresenter(IKernel k, IGreenhouse g, IAddDevicesView v)
        {
            kernel = k;
            model = g;
            view = v;

            //event subscription
            view.add += add;
            view.delete += delete;
        }

        public void add(object o, Location l)
        {
            //parsing
            //model manipulation
            //view manipulation
            //SENSORS
            try
            {
                if (o == view.currentComboBox.Items[0])
                {
                    model.currentSensorMap.mapOfAciditySensors.Add(l, ConcreteFactory.createAciditySensor(l));
                }
                else if (o == view.currentComboBox.Items[1])
                {
                    model.currentSensorMap.mapOfLightSensors.Add(l, ConcreteFactory.createLightSensor(l));
                }
                else if (o == view.currentComboBox.Items[2])
                {
                    model.currentSensorMap.mapOfTemperatureSensors.Add(l, ConcreteFactory.createTemperatureSensor(l));
                }
                else if (o == view.currentComboBox.Items[3])
                {
                    model.currentSensorMap.mapOfWetnessSensors.Add(l, ConcreteFactory.createWetnessSensor(l));
                }
                //REGULATORS
                else if (o == view.currentComboBox.Items[4])
                {
                    model.currentRegulatorMap.mapOfAcidityRegulators.Add(l,
                               ConcreteFactory.createAcidityRegulator(l, ACIDITY_MAX_POWER));
                }
                else if (o == view.currentComboBox.Items[5])
                {
                    model.currentRegulatorMap.mapOfLightRegulators.Add(l,
                        ConcreteFactory.createLightRegulator(l, LIGHT_MAX_POWER));
                }
                else if (o == view.currentComboBox.Items[6])
                {
                    model.currentRegulatorMap.mapOfTemperatureRegulators.Add(l,
                        ConcreteFactory.createTemperatureRegulator(l, TEMPERATURE_MAX_POWER));
                }
                else if (o == view.currentComboBox.Items[7])
                {
                    model.currentRegulatorMap.mapOfWetnessRegulators.Add(l,
                        ConcreteFactory.createWetnessRegulator(l, WETNESS_MAX_POWER));
                }
                else throw new Exception("Type doesn`t match");
            }
            catch (ArgumentException e)
            {
                //element already exists
            }
            view.addDeviceToList(o.ToString(), l);
        }
        public void delete(string s)
        {
            bool result = false;
                string str = s;
                string[] strArr = str.Split('.');
                string[] strArr1 = strArr[1].Split(' ');
                int xCoord = Int32.Parse(strArr1[1].Split(':')[1]);//strArr1[1].Substring(0, 2));
                int yCoord = Int32.Parse(strArr1[2].Split(':')[1]);//strArr1[2].Substring(0, 2));
                switch (strArr[0])
                {
                    case "Acidity Sensor":
                        result = model.currentSensorMap.mapOfAciditySensors.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Light Sensor":
                        result = model.currentSensorMap.mapOfLightSensors.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Temperature Sensor":
                        result = model.currentSensorMap.mapOfTemperatureSensors.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Wetness Sensor":
                        result = model.currentSensorMap.mapOfWetnessSensors.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Acidity Regulator":
                        result = model.currentRegulatorMap.mapOfAcidityRegulators.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Light Regulator":
                        result = model.currentRegulatorMap.mapOfLightRegulators.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Temperature Regulator":
                        result = model.currentRegulatorMap.mapOfTemperatureRegulators.Remove(new Location(xCoord, yCoord));
                        break;
                    case "Wetness Regulator":
                    result = model.currentRegulatorMap.mapOfWetnessRegulators.Remove(new Location(xCoord, yCoord));
                    break;
                }
            if (!result)
            {
                //cannot delete
            }
            view.deleteDeviceFromList();
        }

        public void run()
        {

            view.Show();
        }
    }
}

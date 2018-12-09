using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenHouse.Controllers;
using GreenHouse.Regulators;
using GreenHouse.Sensors;
using Presenter;

namespace View
{
    public partial class AddDevicesView : Form
    {
        public delegate void actionRegulator(Location l, double power);
        public delegate void actionSensor(Location l);
        //reg add
        public event actionRegulator acidityRegulatorAdd;
        public event actionRegulator lightRegulatorAdd;
        public event actionRegulator temperatureRegulatorAdd;
        public event actionRegulator wetnessRegulatorAdd;
        //reg del
        public event actionSensor acidityRegulatorDelete;       //Action sensor delegate type just because of method params
        public event actionSensor lightRegulatorDelete;
        public event actionSensor temperatureRegulatorDelete;
        public event actionSensor wetnessRegulatorDelete;

        //sens add
        public event actionSensor aciditySensorAdd;
        public event actionSensor lightSensorAdd;
        public event actionSensor temperatureSensorAdd;
        public event actionSensor wetnessSensorAdd;
        //sens del
        public event actionSensor aciditySensorDelete;
        public event actionSensor lightSensorDelete;
        public event actionSensor temperatureSensorDelete;
        public event actionSensor wetnessSensorDelete;

        public const double ACIDITY_MAX_POWER = 12;
        public const double LIGHT_MAX_POWER = 35;
        public const double TEMPERATURE_MAX_POWER = 120;
        public const double WETNESS_MAX_POWER = 100;

        private static System.Windows.Forms.ListBox stListOfDevices;
        //private static List<IController> listOfControllers;
        //private static List<ISensor> listOfSensors;
        //private static List<IRegulator> listOfRegulators;

        static AddDevicesView()
        {
            //listOfControllers = new List<IController>();
            //listOfSensors = new List<ISensor>();
            //listOfRegulators = new List<IRegulator>();
            stListOfDevices = new System.Windows.Forms.ListBox();
            stListOfDevices.FormattingEnabled = true;
            stListOfDevices.ItemHeight = 16;
            stListOfDevices.Location = new System.Drawing.Point(13, 13);
            stListOfDevices.Name = "ListOfDevices";
            stListOfDevices.Size = new System.Drawing.Size(392, 116);
            stListOfDevices.TabIndex = 0;
        }

        public AddDevicesView()
        {
            //reg add
            acidityRegulatorAdd += AddDevicesPresenter.addAcidityRegulator;
            lightRegulatorAdd += AddDevicesPresenter.addLightRegulator;
            temperatureRegulatorAdd += AddDevicesPresenter.addTemperatureRegulator;
            wetnessRegulatorAdd += AddDevicesPresenter.addWetnessRegulator;
            //reg del
            acidityRegulatorDelete += AddDevicesPresenter.deleteAcidityRegulator;
            lightRegulatorDelete += AddDevicesPresenter.deleteLightRegulator;
            temperatureRegulatorDelete += AddDevicesPresenter.deleteTemperatureRegulator;
            wetnessRegulatorDelete += AddDevicesPresenter.deleteWetnessRegulator;
            //sens add
            aciditySensorAdd += AddDevicesPresenter.addAciditySensor;
            lightSensorAdd += AddDevicesPresenter.addLightSensor;
            temperatureSensorAdd += AddDevicesPresenter.addTemperatureSensor;
            wetnessSensorAdd += AddDevicesPresenter.addWetnessSensor;
            //sens del
            aciditySensorDelete += AddDevicesPresenter.deleteAciditySensor;
            lightSensorDelete += AddDevicesPresenter.deleteLightSensor;
            temperatureSensorDelete += AddDevicesPresenter.deleteTemperatureSensor;
            wetnessSensorDelete += AddDevicesPresenter.deleteWetnessSensor;

            InitializeComponent();
            foreach (object row in stListOfDevices.Items)
            {
                ListOfDevices.Items.Add(row.ToString());
            }
            //ListOfDevices = stListOfDevices;
        }
        //close
        private void button3_Click(object sender, EventArgs e)
        {
            /*
            //add devices deployng to ghc
            int acidityCountS = 0;
            int lightCountS = 0;
            int temperatureCountS = 0;
            int wetnessCountS = 0;
            foreach (ISensor sensor in listOfSensors)
            {
                if (sensor.GetType() == typeof(AciditySensor)) acidityCountS++;
                if (sensor.GetType() == typeof(LightSensor)) lightCountS++;
                if (sensor.GetType() == typeof(TemperatureSensor)) temperatureCountS++;
                if (sensor.GetType() == typeof(WetnessSensor)) wetnessCountS++;
            }
            int acidityCountR = 0;
            int lightCountR = 0;
            int temperatureCountR = 0;
            int wetnessCountR = 0;
            foreach (IRegulator regulator in listOfRegulators)
            {
                if (regulator.GetType() == typeof(AcidityRegulator)) acidityCountR++;
                if (regulator.GetType() == typeof(LightRegulator)) lightCountR++;
                if (regulator.GetType() == typeof(TemperatureRegulator)) temperatureCountR++;
                if (regulator.GetType() == typeof(WetnessRegulator)) wetnessCountR++;
            }
            AcidityController ac = new AcidityController(acidityCountS, acidityCountR);
            LightController lc = new LightController(lightCountS, lightCountR);
            TemperatureController tc = new TemperatureController(temperatureCountS, temperatureCountR);
            WetnessController wc = new WetnessController(wetnessCountS, wetnessCountR);
            foreach (ISensor sensor in listOfSensors)
            {
                if (sensor.GetType() == typeof(AciditySensor)) ac.addSensor(sensor);
                if (sensor.GetType() == typeof(LightSensor)) lc.addSensor(sensor);
                if (sensor.GetType() == typeof(TemperatureSensor)) tc.addSensor(sensor);
                if (sensor.GetType() == typeof(WetnessSensor)) wc.addSensor(sensor);
            }
            foreach (IRegulator regulator in listOfRegulators)
            {
                if (regulator.GetType() == typeof(AcidityRegulator)) ac.addRegulator(regulator);
                if (regulator.GetType() == typeof(LightRegulator)) lc.addRegulator(regulator);
                if (regulator.GetType() == typeof(TemperatureRegulator)) tc.addRegulator(regulator);
                if (regulator.GetType() == typeof(WetnessRegulator)) wc.addRegulator(regulator);
            }
            listOfControllers.Clear();
            listOfControllers.Add(ac);
            listOfControllers.Add(lc);
            listOfControllers.Add(tc);
            listOfControllers.Add(wc);
            GreenhouseClass.set(listOfControllers);*/
            stListOfDevices = ListOfDevices;
            this.Close();
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            //SENSORS
            if (comboBox1.SelectedItem == comboBox1.Items[0])
            {
                //listOfSensors.Add(new AciditySensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
                aciditySensorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[1])
            {
                //listOfSensors.Add(new LightSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
                lightSensorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[2])
            {
                //listOfSensors.Add(new TemperatureSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
                temperatureSensorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[3])
            {
                //listOfSensors.Add(new WetnessSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
                wetnessSensorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            //REGULATORS
            else if (comboBox1.SelectedItem == comboBox1.Items[4])
            {
                //listOfRegulators.Add(new AcidityRegulator(Int32.Parse(textBox1.Text),
                //    Int32.Parse(textBox2.Text), ACIDITY_MAX_POWER));
                acidityRegulatorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)), ACIDITY_MAX_POWER);
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[5])
            {
                //listOfRegulators.Add(new LightRegulator(Int32.Parse(textBox1.Text),
                //    Int32.Parse(textBox2.Text), LIGHT_MAX_POWER));
                lightRegulatorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)), LIGHT_MAX_POWER);
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[6])
            {
                //listOfRegulators.Add(new TemperatureRegulator(Int32.Parse(textBox1.Text),
                //    Int32.Parse(textBox2.Text), TEMPERATURE_MAX_POWER));
                temperatureRegulatorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)), TEMPERATURE_MAX_POWER);
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[7])
            {
                //listOfRegulators.Add(new WetnessRegulator(Int32.Parse(textBox1.Text),
                //    Int32.Parse(textBox2.Text), WETNESS_MAX_POWER));
                wetnessRegulatorAdd(new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)), WETNESS_MAX_POWER);
            }
            else throw new Exception("Type doesn`t match");
            //add to list
            ListOfDevices.Items.Add(comboBox1.Text + ". X:" + textBox1.Text + " Y:" + textBox2.Text);
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ListOfDevices.SelectedItem.ToString();
                string[] strArr = str.Split('.');
                string[] strArr1 = strArr[1].Split(' ');
                int xCoord = Int32.Parse(strArr1[1].Split(':')[1]);//strArr1[1].Substring(0, 2));
                int yCoord = Int32.Parse(strArr1[2].Split(':')[1]);//strArr1[2].Substring(0, 2));
                switch (strArr[0])
                {
                    case "Acidity Sensor":
                        aciditySensorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Light Sensor":
                        lightSensorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Temperature Sensor":
                        temperatureSensorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Wetness Sensor":
                        wetnessSensorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Acidity Regulator":
                        acidityRegulatorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Light Regulator":
                        lightRegulatorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Temperature Regulator":
                        temperatureRegulatorDelete(new Location(xCoord, yCoord));
                        break;
                    case "Wetness Regulator":
                        wetnessRegulatorDelete(new Location(xCoord, yCoord));
                        break;
                }
                ListOfDevices.Items.Remove(ListOfDevices.SelectedItem);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You cannot delete unselected item!");
            }
        }

        //private void AddDevices_Load(object sender, EventArgs e)
        //{
        //    button3_Click(sender, e);
        //}
    }
}

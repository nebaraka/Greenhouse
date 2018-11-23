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

namespace GreenHouse
{
    public partial class AddDevices : Form
    {
        public const double ACIDITY_MAX_POWER = 12;
        public const double LIGHT_MAX_POWER = 35;
        public const double TEMPERATURE_MAX_POWER = 120;
        public const double WETNESS_MAX_POWER = 100;
        private static List<IController> listOfControllers;
        private static List<ISensor> listOfSensors;
        private static List<IRegulator> listOfRegulators;

        static AddDevices()
        {
            listOfControllers = new List<IController>();
            listOfSensors = new List<ISensor>();
            listOfRegulators = new List<IRegulator>();
        }

        public AddDevices()
        {
            InitializeComponent();
        }
        //close
        private void button3_Click(object sender, EventArgs e)
        {
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
            GreenhouseClass.set(listOfControllers);
            this.Close();
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            //SENSORS
            if (comboBox1.SelectedItem == comboBox1.Items[0])
            {
                listOfSensors.Add(new AciditySensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[1])
            {
                listOfSensors.Add(new LightSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[2])
            {
                listOfSensors.Add(new TemperatureSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[3])
            {
                listOfSensors.Add(new WetnessSensor(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            }
            //REGULATORS
            else if (comboBox1.SelectedItem == comboBox1.Items[4])
            {
                listOfRegulators.Add(new AcidityRegulator(Int32.Parse(textBox1.Text),
                    Int32.Parse(textBox2.Text), ACIDITY_MAX_POWER));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[5])
            {
                listOfRegulators.Add(new LightRegulator(Int32.Parse(textBox1.Text),
                    Int32.Parse(textBox2.Text), LIGHT_MAX_POWER));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[6])
            {
                listOfRegulators.Add(new TemperatureRegulator(Int32.Parse(textBox1.Text),
                    Int32.Parse(textBox2.Text), TEMPERATURE_MAX_POWER));
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[7])
            {
                listOfRegulators.Add(new WetnessRegulator(Int32.Parse(textBox1.Text),
                    Int32.Parse(textBox2.Text), WETNESS_MAX_POWER));
            }
            else throw new Exception("Type doesn`t match");
            //add to list
            ListOfDevices.Items.Add(comboBox1.Text + " X:" + textBox1.Text + " Y:" + textBox2.Text);
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            string str = ListOfDevices.SelectedItem.ToString();
            string[] strArr = str.Split(' ');
            switch (strArr[0])
            {
                case "Acidity Sensor":
                    listOfControllers[0].deleteSensor(string[] strs);
                    break;
            }
           // listOfControllers.Remove();
        }
    }
}

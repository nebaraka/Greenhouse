using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter;

namespace View
{
    public partial class GreenhouseView : Form, IGreenhouseView
    {
        public GreenhouseView()
        {
            InitializeComponent();
            button2.Click += new EventHandler(button2_click);
        }

        public event Action addDevices;
        public event Action configurePlan;
        public event Action startSimulation;
        public event Action showGrowthRates;
        public event Action saveConfiguration;
        public event Action aAlloc;
        public event Action lAlloc;
        public event Action tAlloc;
        public event Action wAlloc;

        public void setTime(int t)
        {
            time_label.Text = t + (t % 10 == 1?" day":" days");
        }
        public void setAcidity(double a)
        {
            acidity_label.Text = a.ToString();
        }
        public void setLight(double l)
        {
            light_label.Text = l.ToString();
        }
        public void setTemperature(double t)
        {
            temperature_label.Text = t.ToString();
        }
        public void setWetness(double w)
        {
            wetness_label.Text = w.ToString();
        }
        public void setRegulators()
        {

        }
        public void setSensors()
        {

        }

        public void show()
        {
            throw new Exception("Method is unsupported");
        }
        public void close()
        {
            Application.Exit();
        }

        private void button2_click(object sender, EventArgs e)
        {
            PlanConfigurationView pc = new PlanConfigurationView();
            pc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDevicesView ad = new AddDevicesView();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GrowthRatesView gr = new GrowthRatesView();
            gr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveConfigurationView sc = new SaveConfigurationView();
            sc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.close();
        }
        //start simulation
        private void button1_Click(object sender, EventArgs e)
        {
            /*if (GreenhouseClass.isListNull())
            {
                MessageBox.Show("Ya canna start dat method weil n' devices!\n"
                    + "(You cannot simulate while there`s no devices)");
            }
            else GreenhouseClass.simulate();*/
        }
    }
}

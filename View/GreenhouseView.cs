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
            base.Invoke(() => this.light_label.Text = "");
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
            time_label.Text = t.ToString() + (t % 10 == 1?" day":" days");
        }
        public void setAcidity(string s)
        {
            acidity_label.Text = s;
        }
        public void setLight(string s)
        {
            light_label.Text = s;
        }
        public void setTemperature(string s)
        {
            temperature_label.Text = s + "C";
        }
        public void setWetness(string s)
        {
            wetness_label.Text = s;
        }

        public void setRegulators()
        {
            //extension
        }
        public void setSensors()
        {
            //extension
        }
        public void Close()
        {
            Application.Exit();
        }

        private void button2_click(object sender, EventArgs e)
        {
            //PlanConfigurationView pc = new PlanConfigurationView();
            //pc.Show();
            configurePlan?.Invoke();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addDevices?.Invoke();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //GrowthRatesView gr = new GrowthRatesView();
            //gr.Show();
            showGrowthRates?.Invoke();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SaveConfigurationView sc = new SaveConfigurationView();
            //sc.Show();
            saveConfiguration?.Invoke();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
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
            startSimulation?.Invoke();
        }
    }
}

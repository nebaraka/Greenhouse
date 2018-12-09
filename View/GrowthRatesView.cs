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
    public partial class GrowthRatesView : Form, IGrowthRatesView
    {
        public GrowthRatesView()
        {
            InitializeComponent();
        }

        public void buildAcidityGraph()
        {

        }
        public void buildLightGraph()
        {

        }
        public void buildTemperatureGraph()
        {

        }
        public void buildWetnessGraph()
        {

        }

        public void showAcidity(double a)
        {
            acidity_label.Text = a.ToString();
        }
        public void showLight(double l)
        {
            light_label.Text = l.ToString();
        }
        public void showTemperature(double t)
        {
            temperature_label.Text = t.ToString();
        }
        public void showWetness(double w)
        {
            wetness_label.Text = w.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

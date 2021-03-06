﻿using System;
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
    public partial class PlanConfigurationView : Form, IPlanConfigurationView
    {
        public PlanConfigurationView()
        {
            InitializeComponent();

        }

        public event planDelegates.del ConfirmPlan;

        public string GetTemperatureCorridors => textBox1.Text;
        public string GetLightCorridors => textBox2.Text;
        public string GetAcidityCorridors => textBox3.Text;
        public string GetWetnessCorridors => textBox4.Text;
        public string GetTemperatureIntervals => textBox5.Text;
        public string GetLightIntervals => textBox6.Text;
        public string GetAcidityIntervals => textBox7.Text;
        public string GetWetnessIntervals => textBox8.Text;
        public void ShowMessage(string s)
        {
            MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PlanConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmPlan?.Invoke(GetTemperatureCorridors, GetLightCorridors, GetAcidityCorridors, GetWetnessCorridors,
                GetTemperatureIntervals, GetLightIntervals, GetAcidityIntervals, GetWetnessIntervals);
        }
        
    }
}

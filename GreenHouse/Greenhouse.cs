using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse
{
    public partial class Greenhouse : Form
    {
        public Greenhouse()
        {
            InitializeComponent();
            button2.Click += new EventHandler(button2_click);
        }
        private void button2_click(object sender, EventArgs e)
        {
            PlanConfiguration pc = new PlanConfiguration();
            pc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDevices ad = new AddDevices();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GrowthRates gr = new GrowthRates();
            gr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveConfiguration sc = new SaveConfiguration();
            sc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //start simulation
        private void button1_Click(object sender, EventArgs e)
        {
            if (GreenhouseClass.isListNull())
            {
                MessageBox.Show("Ya canna start dat method weil n' devices!\n"
                    + "(You cannot simulate while there`s no devices)");
            }
            else GreenhouseClass.simulate();
        }
    }
}

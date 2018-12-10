using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class AddDevicesView : Form, IAddDevicesView
    {

        public event Delegates.addDel add;
        public event Delegates.del delete;
        
        public AddDevicesView()
        {
            InitializeComponent();
        }

        public void addDeviceToList(string s, Location l)
        {
            ListOfDevices.Items.Add(s + ". X:" + l.x + " Y:" + l.y);
        }
        public void deleteDeviceFromList()
        {
            ListOfDevices.Items.Remove(ListOfDevices.SelectedItem);
        }
        //public void initializeList()
        //{

        //}
        public ComboBox currentComboBox
        {
            get { return comboBox1; }
        }
        //close
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            add?.Invoke(comboBox1.SelectedItem, new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
            //add(comboBox1.SelectedItem, new Location(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)));
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (ListOfDevices.SelectedItem != null)
            {
                delete?.Invoke(ListOfDevices.SelectedItem.ToString());
            }
            else
            {
                //messge
            }
        }
    }
}

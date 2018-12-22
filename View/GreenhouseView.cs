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
using System.Drawing.Drawing2D;
using View.Properties;

namespace View
{
    public partial class GreenhouseView : Form, IGreenhouseView
    {
        private Graphics g;
        private const int CELLS_AMOUNT = 20;
        public GreenhouseView()
        {
            InitializeComponent();
            button2.Click += new EventHandler(button2_click);
            //base.Invoke(() => this.light_label.Text = "");
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            Pen myPen = new Pen(Color.Black, 1);
            for (int i = 0; i < pictureBox1.Width; i += pictureBox1.Width / CELLS_AMOUNT)
            {
                g.DrawLine(myPen, new Point(i, 0), new Point(i, pictureBox1.Height));
            }

            for (int i = 0; i < pictureBox1.Height; i += pictureBox1.Height / CELLS_AMOUNT)
            {
                g.DrawLine(myPen, new Point(0, i), new Point(pictureBox1.Width, i));
            }
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
            Action action = () =>
            {
                time_label.Text = t.ToString() + (t % 10 == 1 ? " day" : " days");
            };
            Invoke(action);

        }
        public void setAcidity(string s)
        {
            Action action = () =>
            {
                acidity_label.Text = s;
            };
            Invoke(action);
        }
        public void setLight(string s)
        {
            Action action = () =>
            {
                light_label.Text = s;
            };
            Invoke(action);
        }
        public void setTemperature(string s)
        {
            Action action = () =>
            {
                temperature_label.Text = s + "C";
            };
            Invoke(action);
        }
        public void setWetness(string s)
        {
            Action action = () =>
            {
                wetness_label.Text = s;
            };
            Invoke(action);
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
        public void drawAcidityAllocation(int x, int y, double relation)
        {
            //button11_Click(new object(), new EventArgs());

            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Color c = Color.FromArgb((int)(255 * relation), Color.Green);
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle(x * widthStep + 1, y * heightStep + 1, widthStep - 1, heightStep - 1);
            g.FillRectangle(b, r);
        }
        public void drawLightAllocation(int x, int y, double relation)
        {
            //button11_Click(new object(), new EventArgs());
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            int buf = 0;
            if (relation >= 0 && relation < 256) buf = (int)(255 * relation);
            Color c = Color.FromArgb(buf, Color.Yellow);
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle(x * widthStep + 1, y * heightStep + 1, widthStep - 1, heightStep - 1);
            g.FillRectangle(b, r);
        }
        public void drawTemperatureAllocation(int x, int y, double relation)
        {
            //button11_Click(new object(), new EventArgs());
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Color c = Color.FromArgb((int)(255 * relation), Color.Red);
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle(x * widthStep + 1, y * heightStep + 1, widthStep - 1, heightStep - 1);
            g.FillRectangle(b, r);
        }
        public void drawWetnessAllocation(int x, int y, double relation)
        {
            //button11_Click(new object(), new EventArgs());
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Color c = Color.FromArgb((int)(255 * relation), Color.Blue);
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle(x * widthStep + 1, y * heightStep + 1, widthStep - 1, heightStep - 1);
            g.FillRectangle(b, r);
        }
        public void ShowMessage(string s)
        {
            MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        public void drawAcidityRegulator(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.acidityRegulator;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawAciditySensor(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.aciditySensor;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawLightRegulator(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.lightRegulator;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawLightSensor(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.lightSensor;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawTemperatureRegulator(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.temperatureRegulator;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawTemperatureSensor(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.temperatureSensor;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawWetnessRegulator(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.wetnessRegulator;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
        }
        public void drawWetnessSensor(int x, int y)
        {
            int widthStep = pictureBox1.Width / CELLS_AMOUNT;
            int heightStep = pictureBox1.Height / CELLS_AMOUNT;
            Bitmap image = Resources.wetnessSensor;
            //image.SetResolution(widthStep - 2, heightStep - 2);
            g.DrawImage(image, x * widthStep + 1, y * heightStep + 1);
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

        //debug button
        private void button11_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Pen myPen = new Pen(Color.Black, 1);
            for (int i = 0; i < pictureBox1.Width; i += pictureBox1.Width / CELLS_AMOUNT)
            {
                g.DrawLine(myPen, new Point(i, 0), new Point(i, pictureBox1.Height));
            }

            for (int i = 0; i < pictureBox1.Height; i += pictureBox1.Height / CELLS_AMOUNT)
            {
                g.DrawLine(myPen, new Point(0, i), new Point(pictureBox1.Width, i));
            }
        }
        //acidity allocation
        private void button8_Click(object sender, EventArgs e)
        {
            aAlloc?.Invoke();
        }
        //light allocation
        private void button7_Click(object sender, EventArgs e)
        {
            lAlloc?.Invoke();
        }
        //temperature allocation
        private void button6_Click(object sender, EventArgs e)
        {
            tAlloc?.Invoke();
        }
        //wetness allocation
        private void button9_Click(object sender, EventArgs e)
        {
            wAlloc?.Invoke();
        }
    }
}

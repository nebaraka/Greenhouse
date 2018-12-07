using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse
{
    class TemperatureController : IController
    {
        private bool[] commandValues;
        private double[] powerValues;
        private double[] recievedValues;
        private Dictionary<Location, TemperatureRegulator> mapOfRegulators;
        private Dictionary<Location, TemperatureSensor> mapOfSensors;

        public TemperatureController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            powerValues = new double[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            mapOfRegulators = new Dictionary<Location, TemperatureRegulator>(regulatorsAmount);
            mapOfSensors = new Dictionary<Location, TemperatureSensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r, Location loc)
        {
            mapOfRegulators.Add(loc, (TemperatureRegulator)r);
        }
        public void addSensor(ISensor s, Location loc)
        {
            mapOfSensors.Add(loc, (TemperatureSensor)s);
        }
        public void deleteRegulator(string[] strs)
        {
            //TODO
        }
        public void deleteSensor(string[] strs)
        {
            //TODO
        }
        public void askSensors()
        {
            /*int i = 0;//Counter
            foreach (TemperatureSensor sensor in listOfSensors)
            {
                recievedValues[i] = sensor.returnValue();
                i++;
            }*/
        }
        public void calculate()
        {
            /*int regQuantity = listOfRegulators.Count();//Количество регуляторов
            int sensQuantity = listOfSensors.Count();//Количество сенсоров
            Cmatrix weightCoefficients = new Cmatrix(sensQuantity, regQuantity);//How sensors are effected by regulators(degrees/degrees)
            int i = 0, j = 0;//Counters
            foreach (TemperatureSensor sensor in listOfSensors)//Weight Coefficients counting
            {
                int x = sensor.getX();
                int y = sensor.getY();
                foreach (TemperatureRegulator regulator in listOfRegulators)
                {
                    int x1 = regulator.getX();
                    int y1 = regulator.getY();
                    double r = Math.Sqrt(Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2));
                    weightCoefficients.M[i, j] = 1 / (r + 0.5);//Why 0.5? Because.
                    j++;
                }
                i++;
                j = 0;
            }
            double[] neededValues = GrowthPlan.getTemperature();//Corridor
            double averageValue = (neededValues[0] + neededValues[1]) / 2;//Average Value
            Cmatrix regValues = new Cmatrix(regQuantity, 1);//X vector
            Cmatrix sensValues = new Cmatrix(sensQuantity, 1);//Вектор Y
            Cmatrix H = new Cmatrix(regQuantity, 1);//Step
            for (i = 0; i < regQuantity; i++)
            {
                H.M[i, 0] = 1;
            }
            regValues = hookJivsMethod(regValues, sensValues, weightCoefficients, H, 2.5, 0.1, averageValue, neededValues);
            const double h = 2;//Lenght of cells(in meters)
            const double density = 1.2;//(kg/m^3)
            const double c = 1005;//Thermal conductivity
            double coefQ = c * h * density;
            double t = 60;//Time of iteration
            regValues *= coefQ / t;
            for (i = 0; i < regQuantity; i++)
            {
                powerValues[i] = regValues.M[i, 0];
                if (powerValues[i] == 0) commandValues[i] = false;
                else commandValues[i] = true;
            }*/
        }
        /*private double tuskFunction(Cmatrix X, Cmatrix Y, Cmatrix A, double averageValue, double[] neededValues)
        {
            double f = 0;
            Y = A * X;
            for (int i = 0; i < Y.strok(); i++)
            {
                f += Math.Abs(averageValue - Y.M[i, 0]);
                if (Y.M[i, 1] > neededValues[1] || Y.M[i, 0] < neededValues[0]) f += 10000;
            }
            return f;
        }*/
        /*private Cmatrix coordSearch(Cmatrix X, Cmatrix Y, Cmatrix H, Cmatrix A, double averageValue, double[] neededValues)
        {
            double z = tuskFunction(X, Y, A, averageValue, neededValues);
            Cmatrix Xnew = new Cmatrix(X);
            for (int i = 0; i < X.strok(); i++)
            {
                Xnew.M[i, 0] += H.M[i, 0];
                if (z < tuskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew.M[i, 0] = X.M[i, 0] - H.M[i, 0];
                if (z < tuskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew.M[i, 0] = X.M[i, 0];
            }
            return Xnew;
        }*/
       /* private Cmatrix hookJivsMethod(Cmatrix X0, Cmatrix Y, Cmatrix A, Cmatrix H, double l, double eps, double averageValue, double[] neededValues)
        {
            /*double delta = H.norm();
            Cmatrix Xb = new Cmatrix(X0);
            while (true)
            {
                Cmatrix Xs = coordSearch(Xb, Y, H, A, averageValue, neededValues);
                if (Xs == Xb)
                {
                    H /= 10; delta /= 10; //Ліміт блізка *)
                    if (delta < eps) break;
                    else continue;
                };
                while (true)
                {
                    Cmatrix Xp = Xb + (Xs - Xb) * 2.5; // Рух уздоўж яра*)
                    Cmatrix Xq = coordSearch(Xp, Y, H, A, averageValue, neededValues); // Каардынатны спуск *)
                    if (tuskFunction(Xs, Y, A, averageValue, neededValues) <= tuskFunction(Xq, Y, A, averageValue, neededValues))
                    {
                        Xb = Xs; break;//To searching new Xs
                    }
                    else
                    {
                        Xb = Xs; Xs = Xq; continue;//To searching new Xp
                    };

                };
            };
            return Xb;
            
        }*/
        public void setRegulators()
        {

        }
    }
}

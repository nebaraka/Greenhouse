using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Regulators;
using GreenHouse.Sensors;

namespace GreenHouse.Controllers
{
    class LightController : IController
    {
        private bool[] commandValues;
        private double[] recievedValues;
        private List<LightRegulator> listOfRegulators;
        private List<LightSensor> listOfSensors;

        public LightController(int sensorsAmount, int regulatorsAmount)
        {
            commandValues = new bool[regulatorsAmount];
            recievedValues = new double[sensorsAmount];
            listOfRegulators = new List<LightRegulator>(regulatorsAmount);
            listOfSensors = new List<LightSensor>(sensorsAmount);
        }

        public void addRegulator(IRegulator r)
        {
            listOfRegulators.Add((LightRegulator)r);
        }
        public void addSensor(ISensor s)
        {
            listOfSensors.Add((LightSensor)s);
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
            int i = 0;//Counter
            foreach (LightSensor sensor in listOfSensors)
            {
                recievedValues[i] = sensor.returnValue();
                i++;
            }
        }
        public void calculate()
        {
            int regQuantity = listOfRegulators.Count();//Количество регуляторов
            int sensQuantity = listOfSensors.Count();//Количество сенсоров
            Cmatrix weightCoefficients = new Cmatrix(sensQuantity, regQuantity);//How sensors are effected by regulators(degrees/degrees)
            int i = 0, j = 0;//Counters
            foreach (LightSensor sensor in listOfSensors)//Weight Coefficients counting
            {
                int x = sensor.getX();
                int y = sensor.getY();
                foreach (LightRegulator regulator in listOfRegulators)
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
                H.M[i, 1] = 1;
            }
            regValues = hookJivsMethod(regValues, sensValues, weightCoefficients, H, 2.5, 0.1, averageValue, neededValues);
        }
        private double tuskFunction(Cmatrix X, Cmatrix Y, Cmatrix A, double averageValue, double[] neededValues)
        {
            double f = 0;
            Y = A * X;
            for (int i = 0; i < Y.strok(); i++)
            {
                f += Math.Abs(averageValue - Y.M[i, 1]);
                if (Y.M[i, 1] > neededValues[1] || Y.M[i, 1] < neededValues[0]) f += 1000;
            }
            return f;
        }
        private Cmatrix coordSearch(Cmatrix X, Cmatrix Y, Cmatrix H, Cmatrix A, double averageValue, double[] neededValues)
        {
            double z = tuskFunction(X, Y, A, averageValue, neededValues);
            Cmatrix Xnew = new Cmatrix(X);
            for (int i = 0; i < X.strok(); i++)
            {
                Xnew.M[i, 1] += H.M[i, 1];
                if (z < tuskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew.M[i, 1] = X.M[i, 1] - H.M[i, 1];
                if (z < tuskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew.M[i, 1] = X.M[i, 1];
            }
            return Xnew;
        }
        private Cmatrix hookJivsMethod(Cmatrix X0, Cmatrix Y, Cmatrix A, Cmatrix H, double l, double eps, double averageValue, double[] neededValues)
        {
            double delta = H.norm();
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
                        Xb = Xs; break;// Шукаць будзем новае Xs *)
                    }
                    else
                    {
                        Xb = Xs; Xs = Xq; continue;//(*Шукаць будзем новае Xp *)
                    };

                };
            };
            return Xb;
        }
        public void setRegulators()
        {

        }
    }
}

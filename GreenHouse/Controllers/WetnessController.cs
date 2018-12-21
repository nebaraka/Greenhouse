using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.DeviceMaps;
using GreenHouse.Regulators;
using GreenHouse.Sensors;
using MathNet.Numerics.LinearAlgebra;

namespace GreenHouse.Controllers
{
    public class WetnessController : IController
    {
        private double[] powerValues;
        private double[] recievedValues;
        private RegulatorMap rm;
        private SensorMap sm;
        private GrowthPlan gp;

        public WetnessController(RegulatorMap rm, SensorMap sm, GrowthPlan gp)
        {
            this.rm = rm;
            this.sm = sm;
            this.gp = gp;
        }

        public void addRegulator(IRegulator r, Location loc)
        {
            rm.mapOfWetnessRegulators.Add(loc, (WetnessRegulator)r);
        }
        public void addSensor(ISensor s, Location loc)
        {
            sm.mapOfWetnessSensors.Add(loc, (WetnessSensor)s);
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
            if (recievedValues == null) recievedValues = new double[sm.mapOfWetnessSensors.Count];
            foreach (WetnessSensor sensor in sm.mapOfWetnessSensors.Values)
            {
                recievedValues[i] = sensor.returnValue();
                i++;
            }
        }
        public void calculate()
        {
            int regQuantity = rm.mapOfWetnessRegulators.Count();//Количество регуляторов
            int sensQuantity = sm.mapOfWetnessSensors.Count();//Количество сенсоров
            Matrix<double> weightCoefficients = Matrix<double>.Build.DenseDiagonal(sensQuantity, regQuantity, 0);//How sensors are effected by regulators(degrees/degrees)
            int i = 0, j = 0;//Counters
            foreach (Location sensLoc in sm.mapOfWetnessSensors.Keys)//Weight Coefficients counting
            {
                foreach (Location regLoc in rm.mapOfWetnessRegulators.Keys)
                {
                    double r = Math.Sqrt(Math.Pow((sensLoc.x - regLoc.x), 2) + Math.Pow((sensLoc.y - regLoc.y), 2));
                    weightCoefficients[i, j] = 1 / (r + 0.5);//Why 0.5? Because.
                    j++;
                }
                i++;
                j = 0;
            }
            ParamValues.Corridor neededValues = gp.getWetness();//Corridor
            double averageValue = (neededValues.minValue + neededValues.maxValue) / 2;//Average Value
            Vector<double> regValues = Vector<double>.Build.Dense(regQuantity);//X vector
            Vector<double> sensValues = Vector<double>.Build.Dense(sensQuantity);//Вектор Y
            Vector<double> H = Vector<double>.Build.Dense(regQuantity, 5);//Step
            regValues = HookJivsMethod(regValues, sensValues, weightCoefficients, H, 2.5, 0.1, averageValue, neededValues);
            /*if (powerValues == null) powerValues = new double[rm.mapOfWetnessRegulators.Count];
            for (int i = 0; i < powerValues.Length; i++) powerValues[i] = 0;*/
            powerValues = regValues.ToArray();
        }
        private double TaskFunction(Vector<double> X, Vector<double> Y, Matrix<double> A, double averageValue, ParamValues.Corridor neededValues)
        {
            double f = 0;
            Y = A * X + Vector<double>.Build.Dense(recievedValues);
            for (int i = 0; i < Y.Count; i++)
            {
                f += (averageValue - Y[i]) * (averageValue - Y[i]);
                if (Y[i] > neededValues.maxValue || Y[i] < neededValues.maxValue) f += 1000;
            }
            return f;
        }
        private Vector<double> CoordSearch(Vector<double> X, Vector<double> Y, Vector<double> H, Matrix<double> A, double averageValue, ParamValues.Corridor neededValues)
        {
            double z = TaskFunction(X, Y, A, averageValue, neededValues);
            Vector<double> Xnew = Vector<double>.Build.DenseOfVector(X);
            for (int i = 0; i < X.Count; i++)
            {
                Xnew[i] += H[i];
                if (z < TaskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew[i] = X[i] - H[i];
                if (z < TaskFunction(Xnew, Y, A, averageValue, neededValues)) Xnew[i] = X[i];
            }
            return Xnew;
        }
        private Vector<double> HookJivsMethod(Vector<double> X0, Vector<double> Y, Matrix<double> A, Vector<double> H, double l, double eps, double averageValue, ParamValues.Corridor neededValues)
        {
            double delta = H.Norm(2);
            Vector<double> Xb = Vector<double>.Build.DenseOfVector(X0);
            while (true)
            {
                Vector<double> Xs = CoordSearch(Xb, Y, H, A, averageValue, neededValues);
                if (Xs.Equals(Xb))
                {
                    H /= 10; delta /= 10; //Ліміт блізка *)
                    if (delta < eps) break;
                    else continue;
                };
                while (true)
                {
                    Vector<double> Xp = Xb + (Xs - Xb) * 2.5; // Рух уздоўж яра*)
                    Vector<double> Xq = CoordSearch(Xp, Y, H, A, averageValue, neededValues); // Каардынатны спуск *)
                    if (TaskFunction(Xs, Y, A, averageValue, neededValues) <= TaskFunction(Xq, Y, A, averageValue, neededValues))
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
            int i = 0;
            foreach (WetnessRegulator regulator in rm.mapOfWetnessRegulators.Values)
            {
                if (recievedValues[i] < Math.Abs(regulator.getMaxPower()) / 100) regulator.turnOff();
                else { regulator.turnOn(); }
                regulator.work(recievedValues[i]);
                i++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    class Environment
    {
        private struct Cell
        {
            public double acidity;
            public double light;
            public double temperature;
            public double wetness;
        }
        private static Cell[,] cells;
        public const int X_SIZE = 20;
        public const int Y_SIZE = 20;
        public static List<double[]> acidityRegValues;
        public static List<double[]> lightRegValues;
        public static List<double[]> temperatureRegValues;
        public static List<double[]> wetnessRegValues;

        static Environment()
        {
            cells = new Cell[X_SIZE, Y_SIZE];
            acidityRegValues = new List<double[]>();
            lightRegValues = new List<double[]>();
            temperatureRegValues = new List<double[]>();
            wetnessRegValues = new List<double[]>();
        }

        public static void recount()
        {
            /*recountTemperature();
            recountLight();
            recountAcidity();
            recountWetness();*/
        }
        private static void recountTemperature()
        {
          /*const double a = 1, b = 1, h = 2;//Lenght of cells(in meters)
            const double density = 1.2;//(kg/m^3)
            const double c = 1005;//Thermal conductivity
            const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
            foreach (double[] regulator in temperatureRegValues)
            {
                regulator[2] = (regulator[2] * t) / (a * b * h * density * c);//Switching power to temperature change
            }
            for (int k = 0; k < kt; k++)
            {
                foreach (double[] regulator in temperatureRegValues)//Active regulators recount
                {
                    int x = (int)regulator[0];
                    int y = (int)regulator[1];
                    double dt = regulator[2];
                    temperature[x, y] += dt;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (double[] regulator in temperatureRegValues)
                            if ((i == regulator[0]) && (j == regulator[1]) && (regulator[2] != 0))
                            {
                                isActiveRegulator = true;
                                break;
                            }
                        if (isActiveRegulator == false)//Recount others
                        {
                            double coef = 0;//Coefficient to divide
                            double sum = 0;//Nearby cells sum
                            if (i != 0)
                            {
                                sum += temperature[i - 1, j];
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += temperature[i + 1, j];
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += temperature[i, j - 1];
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += temperature[i, j + 1];
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += temperature[i - 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += temperature[i - 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += temperature[i + 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += temperature[i + 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - temperature[i, j];
                            temperature[i, j] += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }

                }
            }*/
        }
        public static void recountLight()
        {
            /*double h = 2;//Height
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                {
                    light[i, j] = 0;
                    foreach (double[] regulator in lightRegValues)
                    {//regulator[2] in lumens
                        double dx = regulator[0] - i;
                        double dy = regulator[1] - j;
                        double r = Math.Sqrt(dx * dx + dy * dy);
                        double R = Math.Sqrt(r * r + h * h);
                        double r1_2 = r - Math.Sqrt(2) / 2;
                        double R1_2 = Math.Sqrt(r1_2 * r1_2 + h * h);
                        light[i, j] += regulator[2] * h * h * h / (R * R * R * R * R) * R1_2 * R1_2;//F*h^3*R1_2^2/R^5
                    }
                }
            }*/
        }
        public static void recountAcidity()
        {
            /*const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
            for (int k = 0; k < kt; k++)
            {
                foreach (double[] regulator in acidityRegValues)//Active regulators recount
                {
                    int x = (int)regulator[0];
                    int y = (int)regulator[1];
                    double dA = regulator[2];//Delta Acidity
                    acidity[x, y] += dA;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (double[] regulator in acidityRegValues)
                            if ((i == regulator[0]) && (j == regulator[1]) && (regulator[2] != 0))
                            {
                                isActiveRegulator = true;
                                break;
                            }
                        if (isActiveRegulator == false)//Recount others
                        {
                            double coef = 0;//Coefficient to divide
                            double sum = 0;//Nearby cells sum
                            if (i != 0)
                            {
                                sum += acidity[i - 1, j];
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += acidity[i + 1, j];
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += acidity[i, j - 1];
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += acidity[i, j + 1];
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += acidity[i - 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += acidity[i - 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += acidity[i + 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += acidity[i + 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - acidity[i, j];
                            acidity[i, j] += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }
                }
            }*/
        }
        public static void recountWetness()
        {
            /*const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
            for (int k = 0; k < kt; k++)
            {
                foreach (double[] regulator in wetnessRegValues)//Active regulators recount
                {
                    int x = (int)regulator[0];
                    int y = (int)regulator[1];
                    double dW = regulator[2];//Delta Wetness
                    wetness[x, y] += dW;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (double[] regulator in wetnessRegValues)
                            if ((i == regulator[0]) && (j == regulator[1]) && (regulator[2] != 0))
                            {
                                isActiveRegulator = true;
                                break;
                            }
                        if (isActiveRegulator == false)//Recount others
                        {
                            double coef = 0;//Coefficient to divide
                            double sum = 0;//Nearby cells sum
                            if (i != 0)
                            {
                                sum += wetness[i - 1, j];
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += wetness[i + 1, j];
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += wetness[i, j - 1];
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += wetness[i, j + 1];
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += wetness[i - 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += wetness[i - 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += wetness[i + 1, j - 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += wetness[i + 1, j + 1] / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - wetness[i, j];
                            wetness[i, j] += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }
                }
            }*/
        }
        public static double getAcididty(int x, int y) { return cells[x,y].acidity; }
        public static double getLight(int x, int y) { return cells[x, y].light; }
        public static double getTemperature(int x, int y) { return cells[x, y].temperature; }
        public static double getWetness(int x, int y) { return cells[x, y].wetness; }
    }
}
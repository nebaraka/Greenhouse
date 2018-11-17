using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    class Environment
    {
        public const int X_SIZE = 20;
        public const int Y_SIZE = 20;
        private static double[,] acidity;
        private static double[,] light;
        private static double[,] temperature;
        private static double[,] wetness;
        public static List<double[]> acidityRegValues;
        public static List<double[]> lightRegValues;
        public static List<double[]> temperatureRegValues;
        public static List<double[]> wetnessRegValues;

        static Environment()
        {
            acidity = new double[X_SIZE, Y_SIZE];
            light = new double[X_SIZE, Y_SIZE];
            temperature = new double[X_SIZE, Y_SIZE];
            wetness = new double[X_SIZE, Y_SIZE];
            acidityRegValues = new List<double[]>();
            lightRegValues = new List<double[]>();
            temperatureRegValues = new List<double[]>();
            wetnessRegValues = new List<double[]>();
        }

        public static void recount()
        {
            recountTemperature();
        }
        private static void recountTemperature()
        {
            const double a = 1, b = 1, h = 2;//Lenght of cells(in meters)
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
                    double dt = regulator[3];
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
                                sum += temperature[i - 1, j - 1] / 2;
                                coef += 0.5;
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += temperature[i - 1, j + 1] / 2;
                                coef += 0.5;
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += temperature[i + 1, j - 1] / 2;
                                coef += 0.5;
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += temperature[i + 1, j + 1] / 2;
                                coef += 0.5;
                            }
                            double delta = (sum / coef) - temperature[i, j];
                            temperature[i, j] += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }

                }
            }
        }
        public static double getAcididty(int x, int y) { return acidity[x, y]; }
        public static double getLight(int x, int y) { return light[x, y]; }
        public static double getTemperature(int x, int y) { return temperature[x, y]; }
        public static double getWetness(int x, int y) { return wetness[x, y]; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    public class Environment
    {
        public struct Cell
        {
            public double acidity;
            public double light;
            public double temperature;
            public double wetness;
        }
        private Cell[,] cells;
        public const int X_SIZE = 20;
        public const int Y_SIZE = 20;
        public List<regPower> acidityRegValues;
        public List<regPower> lightRegValues;
        public List<regPower> temperatureRegValues;
        public List<regPower> wetnessRegValues;

        public Environment()
        {
            cells = new Cell[X_SIZE, Y_SIZE];
            acidityRegValues = new List<regPower>();
            lightRegValues = new List<regPower>();
            temperatureRegValues = new List<regPower>();
            wetnessRegValues = new List<regPower>();
        }

        public void recount()
        {
            recountTemperature();
            recountLight();
            recountAcidity();
            recountWetness();
        }
        private void recountTemperature()
        {
           /* for (int i = 0; i < X_SIZE; i++)
                for (int j = 0; j < Y_SIZE; j++)
                    cells[i, j].temperature = 10;*/
            /*const double a = 1, b = 1, h = 2;//Lenght of cells(in meters)
            const double density = 1.2;//(kg/m^3)
            const double c = 1005;//Thermal conductivity*/
            const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
           /* foreach (double[] regulator in temperatureRegValues)
            {
                regulator[2] = (regulator[2] * t) / (a * b * h * density * c);//Switching power to temperature change
            }*/
            for (int k = 0; k < kt; k++)
            {
                foreach (regPower regPower in temperatureRegValues)//Active regulators recount
                {
                    int x = regPower.loc.x;
                    int y = regPower.loc.y;
                    double dt = regPower.power;
                    cells[x, y].temperature += dt;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (regPower regulator in temperatureRegValues)
                            if ((i == regulator.loc.x) && (j == regulator.loc.y) && (regulator.power != 0))
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
                                sum += cells[i - 1, j].temperature;
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += cells[i + 1, j].temperature;
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += cells[i, j - 1].temperature;
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += cells[i, j + 1].temperature;
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += cells[i - 1, j - 1].temperature / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += cells[i - 1, j + 1].temperature / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += cells[i + 1, j - 1].temperature / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += cells[i + 1, j + 1].temperature / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - cells[i, j].temperature;
                            cells[i, j].temperature += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }

                }
            }
        }
        public void recountLight()
        {
            /*for (int i = 0; i < X_SIZE; i++)
                for (int j = 0; j < Y_SIZE; j++)
                    cells[i, j].light = 20;*/
            double h = 2;//Height
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                {
                    cells[i, j].light = 0;
                    foreach (regPower regulator in lightRegValues)
                    {//regulator[2] in lumens
                        double dx = regulator.loc.x - i;
                        double dy = regulator.loc.y - j;
                        double r = Math.Sqrt(dx * dx + dy * dy);
                        double R = Math.Sqrt(r * r + h * h);
                        double r1_2 = r - Math.Sqrt(2) / 2;
                        double R1_2 = Math.Sqrt(r1_2 * r1_2 + h * h);
                        cells[i, j].light += regulator.power * h * h * h / (R * R * R * R * R) * R1_2 * R1_2;//F*h^3*R1_2^2/R^5
                    }
                }
            }
        }
        public void recountAcidity()
        {
            /*for (int i = 0; i < X_SIZE; i++)
                for (int j = 0; j < Y_SIZE; j++)
                    cells[i, j].acidity = 30;*/
            const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
            for (int k = 0; k < kt; k++)
            {
                foreach (regPower regPower in acidityRegValues)//Active regulators recount
                {
                    int x = regPower.loc.x;
                    int y = regPower.loc.y;
                    double dt = regPower.power;
                    cells[x, y].acidity += dt;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (regPower regulator in acidityRegValues)
                            if ((i == regulator.loc.x) && (j == regulator.loc.y) && (regulator.power != 0))
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
                                sum += cells[i - 1, j].acidity;
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += cells[i + 1, j].acidity;
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += cells[i, j - 1].acidity;
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += cells[i, j + 1].acidity;
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += cells[i - 1, j - 1].acidity / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += cells[i - 1, j + 1].acidity / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += cells[i + 1, j - 1].acidity / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += cells[i + 1, j + 1].acidity / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - cells[i, j].acidity;
                            cells[i, j].acidity += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }
                }
            }
        }
        public void recountWetness()
        {
            /*for (int i = 0; i < X_SIZE; i++)
                for (int j = 0; j < Y_SIZE; j++)
                    cells[i, j].wetness = 40;*/
            const int t = 1;//Time scale(in mins)
            int kt = 60 / t;//Time intervals quantitaty
            for (int k = 0; k < kt; k++)
            {
                foreach (regPower regPower in wetnessRegValues)//Active regulators recount
                {
                    int x = regPower.loc.x;
                    int y = regPower.loc.y;
                    double dt = regPower.power;
                    cells[x, y].wetness += dt;
                }
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        bool isActiveRegulator = false;
                        foreach (regPower regulator in wetnessRegValues)
                            if ((i == regulator.loc.x) && (j == regulator.loc.y) && (regulator.power != 0))
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
                                sum += cells[i - 1, j].wetness;
                                coef++;
                            }
                            if (i != X_SIZE - 1)
                            {
                                sum += cells[i + 1, j].wetness;
                                coef++;
                            }
                            if (j != 0)
                            {
                                sum += cells[i, j - 1].wetness;
                                coef++;
                            }
                            if (j != Y_SIZE - 1)
                            {
                                sum += cells[i, j + 1].wetness;
                                coef++;
                            }
                            if (i != 0 && j != 0)
                            {
                                sum += cells[i - 1, j - 1].wetness / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != 0 && j != Y_SIZE - 1)
                            {
                                sum += cells[i - 1, j + 1].wetness / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != 0)
                            {
                                sum += cells[i + 1, j - 1].wetness / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            if (i != X_SIZE - 1 && j != Y_SIZE - 1)
                            {
                                sum += cells[i + 1, j + 1].wetness / Math.Sqrt(2);
                                coef += Math.Sqrt(2);
                            }
                            double delta = (sum / coef) - cells[i, j].wetness;
                            cells[i, j].wetness += delta * 1.5;//1.5 - relaxation coefficient
                        }
                    }

                }
            }
        }
        public double getAcididty(int x, int y) { return cells[x,y].acidity; }
        public double getLight(int x, int y) { return cells[x, y].light; }
        public double getTemperature(int x, int y) { return cells[x, y].temperature; }
        public double getWetness(int x, int y) { return cells[x, y].wetness; }
        public double AverageAcidity()
        {
            double average = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                double temp = 0;
                for (int j = 0; j < Y_SIZE; j++)
                    temp += cells[i, j].acidity;
                temp /= Y_SIZE;
                average += temp;
            }
            average /= X_SIZE;
            return average;
        }
        public double AverageLight()
        {
            double average = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                double temp = 0;
                for (int j = 0; j < Y_SIZE; j++)
                    temp += cells[i, j].light;
                temp /= Y_SIZE;
                average += temp;
            }
            average /= X_SIZE;
            return average;
        }
        public double AverageTemperature()
        {
            double average = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                double temp = 0;
                for (int j = 0; j < Y_SIZE; j++)
                    temp += cells[i, j].temperature;
                temp /= Y_SIZE;
                average += temp;
            }
            average /= X_SIZE;
            return average;
        }
        public double AverageWetness()
        {
            double average = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                double temp = 0;
                for (int j = 0; j < Y_SIZE; j++)
                    temp += cells[i, j].wetness;
                temp /= Y_SIZE;
                average += temp;
            }
            average /= X_SIZE;
            return average;
        }
        public double MaxAcidity()
        {
            double max = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                    if (max < cells[i, j].acidity) max = cells[i, j].acidity;
            }
            return max;
        }
        public double MaxLight()
        {
            double max = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                    if (max < cells[i, j].light) max = cells[i, j].light;
            }
            return max;
        }
        public double MaxTemperature()
        {
            double max = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                    if (max < cells[i, j].temperature) max = cells[i, j].temperature;
            }
            return max;
        }
        public double MaxWetness()
        {
            double max = 0;
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                    if (max < cells[i, j].wetness) max = cells[i, j].wetness;
            }
            return max;
        }
        public Cell[,] getCells()
        {
            return cells;
        }
    }
}
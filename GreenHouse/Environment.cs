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
        public static List<double> regValues;

        static Environment()
        {
            acidity = new double[X_SIZE, Y_SIZE];
            light = new double[X_SIZE, Y_SIZE];
            temperature = new double[X_SIZE, Y_SIZE];
            wetness = new double[X_SIZE, Y_SIZE];
            regValues = new List<double>();
        }

        public static void recount()
        {

        }

        public static double getAcididty(int x, int y) { return acidity[x, y]; }
        public static double getLight(int x, int y) { return light[x, y]; }
        public static double getTemperature(int x, int y) { return temperature[x, y]; }
        public static double getWetness(int x, int y) { return wetness[x, y]; }
    }
}

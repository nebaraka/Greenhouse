using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    class GrowthPlan
    {
        public const int NUMBER_OF_INTERVALS = 3;

        private static double[,] acidity;
        private static double[,] light;
        private static double[,] temperature;
        private static double[,] wetness;
        private static int time;

        static GrowthPlan()
        {
            acidity = new double[NUMBER_OF_INTERVALS, 2];
            light = new double[NUMBER_OF_INTERVALS, 2];
            temperature = new double[NUMBER_OF_INTERVALS, 2];
            wetness = new double[NUMBER_OF_INTERVALS, 2];
            time = 0;
            //timer initialization
        }

        public double[] getAcididty() { return new double[2]; }
        public double[] getLight() { return new double[2]; }
        public double[] getTemperature() { return new double[2]; }
        public double[] getWetness() { return new double[2]; }
    }
}

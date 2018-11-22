using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GreenHouse
{
    class GrowthPlan
    {
        public const int NUMBER_OF_INTERVALS = 3;
        
        private static paramStruct acidity;
        private static paramStruct light;
        private static paramStruct temperature;
        private static paramStruct wetness;
        private static int time;
        private static int tickSize;

        static GrowthPlan()
        {
            time = 0;
            tickSize = 1;
        }

        public static void initialize(paramStruct a, paramStruct l, paramStruct t, paramStruct w)
        {
            acidity = a;
            light = l;
            temperature = t;
            wetness = w;
            //timer initialization as an alternative way
           /* TimerCallback tcb = new TimerCallback(tick);
            Timer timer = new Timer(tcb, null, 0, 1000);*/
        }

        public static void tick()
        {
            time += tickSize;
        }

        public static void setTickSize(int size)
        {
            tickSize = size;
        }

        //For extensibility algorythms of all theese getters have to be Generizied
        public static double[] getAcididty()
        {
            if (acidity.intervals[0] + acidity.intervals[1] + acidity.intervals[2] <= time)
            {
                double[] result = {acidity.vals[2, 0], acidity.vals[2, 1] };
                return result;
            }
            else if (acidity.intervals[0] + acidity.intervals[1] <= time)
            {
                double[] result = { acidity.vals[1, 0], acidity.vals[1, 1] };
                return result;
            }
            else
            {
                double[] result = { acidity.vals[0, 0], acidity.vals[0, 1] };
                return result;
            }
        }
        public static double[] getLight()
        {
            if (light.intervals[0] + light.intervals[1] + light.intervals[2] <= time)
            {
                double[] result = { light.vals[2, 0], light.vals[2, 1] };
                return result;
            }
            else if (light.intervals[0] + light.intervals[1] <= time)
            {
                double[] result = { light.vals[1, 0], light.vals[1, 1] };
                return result;
            }
            else
            {
                double[] result = { light.vals[0, 0], light.vals[0, 1] };
                return result;
            }
        }
        public static double[] getTemperature()
        {
            if (temperature.intervals[0] + temperature.intervals[1] + temperature.intervals[2] <= time)
            {
                double[] result = { temperature.vals[2, 0], temperature.vals[2, 1] };
                return result;
            }
            else if (temperature.intervals[0] + temperature.intervals[1] <= time)
            {
                double[] result = { temperature.vals[1, 0], temperature.vals[1, 1] };
                return result;
            }
            else
            {
                double[] result = { temperature.vals[0, 0], temperature.vals[0, 1] };
                return result;
            }
        }
        public static double[] getWetness()
        {
            if (wetness.intervals[0] + wetness.intervals[1] + wetness.intervals[2] <= time)
            {
                double[] result = { wetness.vals[2, 0], wetness.vals[2, 1] };
                return result;
            }
            else if (wetness.intervals[0] + wetness.intervals[1] <= time)
            {
                double[] result = { wetness.vals[1, 0], wetness.vals[1, 1] };
                return result;
            }
            else
            {
                double[] result = { wetness.vals[0, 0], wetness.vals[0, 1] };
                return result;
            }
        }
    }
}

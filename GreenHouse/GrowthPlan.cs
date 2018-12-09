using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GreenHouse
{
    public class GrowthPlan
    {
        Time time = new Time();
        private static ParamValues[] values;

        static GrowthPlan()
        {

        }

        public static void Initialize(ParamValues[] paramValues)
        {
            values = paramValues;
            //timer initialization as an alternative way
           /* TimerCallback tcb = new TimerCallback(tick);
            Timer timer = new Timer(tcb, null, 0, 1000);*/
        }

        //For extensibility algorythms of all theese getters have to be Generizied
        public static ParamValues.Corridor getAcidity()
        {
            int currentTime = Time.GetTime();
            int i =-1;
            while (currentTime >= 0) 
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].acidity;
        }
        public static ParamValues.Corridor getLight()
        {
            int currentTime = Time.GetTime();
            int i = -1;
            while (currentTime >= 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].light;
        }
        public static ParamValues.Corridor getTemperature()
        {
            int currentTime = Time.GetTime();
            int i = -1;
            while (currentTime >= 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].temperature;
        }
        public static ParamValues.Corridor getWetness()
        {
            int currentTime = Time.GetTime();
            int i = -1;
            while (currentTime >= 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].wetness;
        }
    }
}

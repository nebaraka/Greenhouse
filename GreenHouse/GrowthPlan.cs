using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GreenHouse
{
    public class GrowthPlan : IGrowthPlan
    {
        Time time;
        private ParamValues[] values;

        public GrowthPlan(Time time)
        {
            this.time = time;
        }

        public void Initialize(ParamValues[] paramValues)
        {
            values = paramValues;
            //timer initialization as an alternative way
           /* TimerCallback tcb = new TimerCallback(tick);
            Timer timer = new Timer(tcb, null, 0, 1000);*/
        }

        //For extensibility algorythms of all theese getters have to be Generizied
        public ParamValues.Corridor getAcidity()
        {
            int currentTime = time.GetTime();
            int i =-1;
            while (currentTime > 0) 
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].acidity;
        }
        public ParamValues.Corridor getLight()
        {
            int currentTime = time.GetTime();
            int i = -1;
            while (currentTime > 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].light;
        }
        public ParamValues.Corridor getTemperature()
        {
            int currentTime = time.GetTime();
            int i = -1;
            while (currentTime > 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].temperature;
        }
        public ParamValues.Corridor getWetness()
        {
            int currentTime = time.GetTime();
            int i = -1;
            while (currentTime > 0)
            {
                currentTime -= values[++i].timeSlice;
            }
            return values[i].wetness;
        }
        public int getOverallTime()
        {
            int result = 0;
            foreach (ParamValues t in values)
            {
                result += t.timeSlice;
            }
            return result;
        }
    }
}

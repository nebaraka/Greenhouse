using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    public class Time
    {
        private int time;
        private int tickSize;
        public Time()
        {
            time = 1;
            tickSize = 1;
        }
        public void Tick()
        {
            time += tickSize;
        }

        public void SetTickSize(int size)
        {
            tickSize = size;
        }
        public int GetTickSize()
        {
            return tickSize;
        }
        public void ResetTime()
        {
            time = 1;
        }

        public int GetTime() { return time; }
    }
}

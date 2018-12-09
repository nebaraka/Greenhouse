using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    public class Time
    {
        private static int time;
        private static int tickSize;
        static Time()
        {
            time = 0;
            tickSize = 1;
        }
        public static void Tick()
        {
            time += tickSize;
        }

        public static void SetTickSize(int size)
        {
            tickSize = size;
        }

        public static int GetTime() { return time; }
    }
}

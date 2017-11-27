using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieFactory
{
    class Spin
    {
        public static void Wait(int milliseconds)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < milliseconds) ;
        }
    }
}

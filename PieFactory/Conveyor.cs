using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    class Conveyor
    {
        public static bool isWorking = true;
        public static bool isStopped = false;
        public static bool stopFactory = false;

        public static void Belt(bool isDispensing ,
            ConcurrentBag<Crust> crusts, AutoResetEvent stopLucy, AutoResetEvent waitLucy)
        {
            var stopwatch = new Stopwatch();
             

            while (isWorking)
            {
                stopwatch.Start();

                Crust newCrust = new Crust();
                crusts.Add(newCrust);

                stopLucy.Set();

                Spin.Wait(50);


                if (isDispensing)
                {
                    waitLucy.WaitOne();
                }

                stopwatch.Stop();

                Console.WriteLine("Pie was created successfully!");
                Console.WriteLine("Time taken for the pie to be created was {0}." + Environment.NewLine, stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();

                if (stopFactory)
                {
                    isWorking = false;
                    isStopped = true;
                }
            }

        }
    }
}

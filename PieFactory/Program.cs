using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hopper hopperFilling = new Hopper();
            Hopper hopperFlavor = new Hopper();
            Hopper hopperTopping = new Hopper();

            Joe joe = new Joe();
            Lucy lucy = new Lucy();

            AutoResetEvent stopLucy = new AutoResetEvent(false);
            AutoResetEvent waitLucy = new AutoResetEvent(false);

            ConcurrentBag<Crust> crusts = new ConcurrentBag<Crust>();

            bool isDispensing = false;
            bool stopFactory = false;
            bool isStoppedSuccessfully = false;

            string startingTheFactory = "START WORKING";

            Console.WriteLine("Press \"ENTER\" to start the factory and press \"ESCAPE\" to stop it.");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)) ;

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, 1);
                startingTheFactory += '.';
                Console.WriteLine(startingTheFactory);
                Spin.Wait(450);
            }
            Console.WriteLine();

             void ConveyorBelt()
            {
                Conveyor.Belt( isDispensing,
                crusts, stopLucy, waitLucy);
            }

            void WorkingLucy()
            {
                lucy.Dispensing(isDispensing,
                hopperFilling, hopperFlavor, hopperTopping, crusts, stopLucy, waitLucy);
            }

            void WorkingJoe()
            {
                joe.FillHoppers(hopperFilling, hopperFlavor, hopperTopping);
            }
            Thread Belt = new Thread(new ThreadStart(ConveyorBelt));

            Thread RobotLucy = new Thread(new ThreadStart(WorkingLucy));

            Thread RobotJoe = new Thread(new ThreadStart(WorkingJoe));


            RobotJoe.Start();
            Belt.Start();
            RobotLucy.Start();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)) ;
            Joe.isWorking= false;
            Conveyor.stopFactory = true;
            do
            {
                if (Conveyor.isStopped)
                {
                    isStoppedSuccessfully = true;
                    Console.WriteLine("Pie factory stopped working successfully!");
                }
            } while (!isStoppedSuccessfully);

        }
    }
}

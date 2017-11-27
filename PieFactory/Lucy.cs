using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    class Lucy
    {
        public static bool isWorking=true;


        public void Spinning()
        {
            Spin.Wait(10);
            
        }

        public void AddFilling(Crust crust, Hopper hopper)
        {
            crust.Filling = 250;
            hopper.Content -= 250;
            Spinning();

        }

        public void AddFlavour(Crust crust, Hopper hopper)
        {
            crust.Flavor = 10;
            hopper.Content -= 10;
            Spinning( );

        }

        public void AddTopping(Crust crust, Hopper hopper)
        {
            crust.Topping = 100;
            hopper.Content -= 100;
            Spinning();

        }

        public bool EnoughForDispensing(Hopper hopper, int quantity)
        {
            return (hopper.Content >= quantity) ? true : false;
        }


              
        public void Dispensing(bool isDispensing, 
            Hopper hopperFilling,Hopper hopperFlavor,Hopper hopperTopping,
            ConcurrentBag<Crust> crusts, AutoResetEvent stopLucy, AutoResetEvent waitLucy)
        {

            while (isWorking)
            {

                stopLucy.WaitOne();
                isDispensing = true;



                while (!this.EnoughForDispensing(hopperFilling, 250))
                {
                    Spin.Wait(1);
                }
                this.AddFilling(crusts.ElementAt(Crust.numberOfPies - 1), hopperFilling);
                Console.WriteLine("Filling was added successfully.");


                while (!this.EnoughForDispensing(hopperFlavor, 10))
                {
                    Spin.Wait(1);
                }
                this.AddFlavour(crusts.ElementAt(Crust.numberOfPies - 1), hopperFlavor);

                Console.WriteLine("Flavor was added successfully.");


                while (!this.EnoughForDispensing(hopperTopping, 100))
                {
                    Spin.Wait(1);
                }
                this.AddTopping(crusts.ElementAt(Crust.numberOfPies - 1), hopperTopping);

                Console.WriteLine("Topping was added successfully.");

                isDispensing = false;
                waitLucy.Set();
            }
        }
        
           
       }

}



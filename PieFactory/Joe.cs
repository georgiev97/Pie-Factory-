using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieFactory
{
    class Joe
    {
        public static bool isWorking=true;


        public void FillHopper(Hopper hopper, int amount)
        {
            if (hopper.Content <= (2000 - amount))
            {
                int iterations = amount / 10;

                for (int i = 0; i < iterations; i++)
                {
                    hopper.Content += 10;
                    Spin.Wait(1);

                }
            }
        }

        public void FillHoppers(Hopper hopperFilling,Hopper hopperFlavor,Hopper hopperTopping)
        {
            while (isWorking)
            {

                this.FillHopper(hopperFilling, 250);

                this.FillHopper(hopperFlavor, 20);

                this.FillHopper(hopperFilling, 70);

                this.FillHopper(hopperTopping, 130);
            }
        }
    }
}

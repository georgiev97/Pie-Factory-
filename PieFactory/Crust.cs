using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieFactory
{
    class Crust
    {
        public int Filling { get; set; }
        public int Flavor { get; set; }
        public int Topping { get; set; }
        public static int numberOfPies = 0;

        public Crust()
        {
            Flavor = 0;
            Filling = 0;
            Topping = 0;
            numberOfPies++;
        }
    }
}

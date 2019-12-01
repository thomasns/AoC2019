using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{



    class Day1
    {
        static void Main(string[] args)
        {


            List<int> Lin = Helpers.readToIntList(1);
            //Part 1
            int sum = 0;
            int fc;
            foreach(int i in Lin) {
                fc = fuelCost(i);
                sum += fc;
            }
            Console.WriteLine(sum);

           //Part 2 

            sum = 0;

            foreach (int i in Lin) {
                fc = fuelCost(i);
                while(fc > 0) {
                    sum += fc;
                    fc = fuelCost(fc);
                }
            }
            Console.WriteLine(sum);
    
            Console.ReadLine();

        }

        public static int fuelCost(int i)
        {
                return (int)((int)(Math.Floor(i / 3d)) - 2);
        }


    }

   
}

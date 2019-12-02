using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{
    class Program
    {


        static void Main(string[] args)
        {

            // pt1 
            List<int> lin = Helpers.readToIntList(2,',');
            int ic = 0;
            int istr;
            lin[1] = 12;
            lin[2] = 2;

            while (true)
            {
                istr = lin[ic];
                if (istr != 99)
                {

                    Step(lin, ic);
                    ic += 4;
                }
                else
                    break;
            }

            Console.WriteLine(lin[0]);
            
            // pt2 

            int noun = 0;
            int verb = 0;
            while (true)
            {
                lin = Helpers.readToIntList(2, ',');
                ic = 0;
                lin[1] = noun;
                lin[2] = verb;

                while (true)
                {
                    istr = lin[ic];
                    if (istr != 99)
                    {

                        Step(lin, ic);
                        ic += 4;
                    }
                    else
                        break;
                }

                if(lin[0] == 19690720)
                {
                    Console.WriteLine(100*noun + verb);
                    break;
                } else
                {
                    verb++;
                    if (verb == 100)
                    {
                        verb = 0;
                        noun++;
                        Console.WriteLine("Miss: " + noun + " " + verb);
                    }
                }

            }
            





            Console.ReadLine();
        }


        static void Step(List<int> mem, int ic)
        {
            int istr = mem[ic];
            int op1 = mem[mem[ic+1]];
            int op2 = mem[mem[ic+2]];
            int sto = mem[ic+3];

            if(istr == 1)
                mem[sto] = op1 + op2;
            if(istr == 2)
                mem[sto] = op1 * op2;


            
        }

    }
}

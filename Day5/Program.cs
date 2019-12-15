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
            Intcode ic = new Intcode(5);
            ic.run();
            Console.ReadLine();
        }
    }
}

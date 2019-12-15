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
            List<string> strIn = Helpers.readToStringList(6);

            Graph map = new Graph();

            //build graph 
            while(strIn.Count > 0)
            {
                if(strIn.Count % 100 == 0)
                    Console.WriteLine("Nodes remaining: " + strIn.Count);
                foreach(string str in strIn)
                {
                    string parentName = str.Split(')')[0].Trim();
                    string childName = str.Split(')')[1].Trim();

                    if (map.tryAdd(parentName, childName)) {
                        strIn.Remove(str);
                        break;
                    }

                }

            

            }

            Console.WriteLine("Total orbits: " + map.countOrbits());
            Console.WriteLine("Total transfers to Santa: " + map.findStepsToSanta());
            Console.ReadLine();


        }
    }
}

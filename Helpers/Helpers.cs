using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AoC2019
{
    class Helpers
    {

        public static void Test()
        {
            int a;
        }
        public static String readToBuffer(int day, string prefix = "") {
            StreamReader sr = new StreamReader(@"C:\Users\thoma\Documents\AoC\input\day"+ prefix + day + @".txt");
            string input = sr.ReadToEnd();
            return input;
        }

        public static List<int> readToIntList(int day, char delim = '\n', string prefix = "")
        {
            String strIn = readToBuffer(day);
            String[] parts = strIn.Trim().Split(delim);

            List<int> lout = new List<int>();
            foreach (string s in parts)
                lout.Add(int.Parse(s));
            return lout;

        }

        public static List<String> readToStringList(int day, char delim = '\n')
        {
            String strIn = readToBuffer(day);
            String[] parts = strIn.Trim().Split(delim);

            return parts.ToList<String>();


        }

        //Find the manhattan distance
        //note to self this should have been in here already
        public static int ManhattanDist(Tuple<int,int> t1, Tuple<int,int> t2)
        {
            return Math.Abs(t1.Item1 - t2.Item1) + Math.Abs(t1.Item2 - t2.Item2);

        }





    }
}

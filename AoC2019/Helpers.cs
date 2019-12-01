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
        public static String readToBuffer(int day) {
            StreamReader sr = new StreamReader(@"C:\Users\oorah\Documents\aoc\input\" + day + @".txt");
            string input = sr.ReadToEnd();
            return input;
        }

        public static List<int> readToIntList(int day, char delim = '\n')
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





    }
}

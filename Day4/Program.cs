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


            String test1 = "112233";
            String test2 = "123444";
            String test3 = "111122";


            Console.WriteLine(Rule1Updated(test1));
            Console.WriteLine(Rule1Updated(test2));
            Console.WriteLine(Rule1Updated(test3));


            int Start = 108457;
            int Stop = 562041;

            int count = 0;
            for (int i = Start; i <= Stop; i++)
                if (Rule1(i.ToString()) && Rule2(i.ToString()))
                    count++;

            Console.WriteLine(count + " total possible combos");

            count = 0;
            for (int i = Start; i <= Stop; i++)
                if (Rule1Updated(i.ToString()) && Rule2(i.ToString()))
                    count++;


            Console.WriteLine(count + " updated total possible combos");
            Console.ReadLine();
        }

        //Returns true if any two adjacent digits are the same
        static bool Rule1(string strIn)
        {
            for(int i = 0; i < 5; i++)
            {
                if (strIn[i] == strIn[i + 1])
                    return true;
            }
            return false;
        }

        //returns true if digits never decrease going from left to right
        static bool Rule2(string strIn)
        {
            for(int i = 0; i < 5; i++)
            {
                if (Int32.Parse(strIn[i].ToString()) > Int32.Parse(strIn[i+1].ToString()))
                    return false;
            }
            return true;
        }

        static bool Rule1Updated(string strIn)
        {
            bool inGroup = false;
            bool found = false;
            for(int i = 0; i < 5; i++)
            {
                if (strIn[i] == strIn[i + 1])
                {
                    if (inGroup)
                        found = false;
                    else
                    {
                        found = true;
                        inGroup = true;
                    }

                }
                else
                {
                    inGroup = false;
                    if (found)
                        return found;
                }
            }

            return found;
        }
    }
}
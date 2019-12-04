using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            
            List<string> lin = Helpers.readToStringList(3, '\n');

            List<ray> Wire1 = new List<ray>();
            List<ray> Wire2 = new List<ray>();

            int wireNo = 1;
            //Read in the individual segments
            foreach(string s in lin)
            {
                int startx = 0;
                int starty = 0;
                int stopx = 0;
                int stopy = 0;
                String[] parts = s.Split(',');

                char dir;
                int dist;
                foreach(string t in parts)
                {
                    dir = t[0];
                    dist = int.Parse(t.Substring(1));
        


                        switch (dir)
                        {
                            case 'U':
                                stopy = starty + dist;
                                startx = stopx;
                                break;
                            case 'D':
                                stopy = starty - dist;
                                startx = stopx;
                                break;
                            case 'L':
                                stopx = startx - dist;
                                starty = stopy;
                                break;
                            case 'R':
                                stopx = startx + dist;
                                starty = stopy;
                                break;
                        }
                        if (wireNo == 1)
                            Wire1.Add(new ray(startx, stopx, starty, stopy));
                        else
                            Wire2.Add(new ray(startx, stopx, starty, stopy));


                        

                
                }
                wireNo = 2;

            }

            List<Tuple<int, int>> intersections = new List<Tuple<int, int>>();
            foreach(ray r in Wire1)
            {
                foreach (ray s in Wire2) {
                    if(r.Crosses(s)) //see if we cross
                        foreach (Tuple<int, int> t in r.findIntersections(s)) //if we do find where and store it
                        {
                            intersections.Add(t);
                        }
                }
            }


            int minDistance = 999999999;
            int d;
            foreach(Tuple<int,int> t in intersections) //Check each crossing for the distance from the orgin and store the lowest non zero
            {
                d = Helpers.ManhattanDist(t, new Tuple<int, int>(0, 0));
                if (d < minDistance && d != 0)
                    minDistance = d;
            }

            Console.WriteLine("Min Dist: " + minDistance);



            //Pt2

            //okay we still have all the intersections stored as tuples... 
            //positions will coorespont do the position of the tuples in t
            List<int> sumCost = new List<int>();

            intersections.RemoveAt(0);
            foreach(Tuple<int,int> t in intersections)
            {
                int w1 = 0;
                int w2 = 0;


                foreach(ray segment in Wire1)
                {
                    if (segment.Crosses(new ray(t.Item1, t.Item1, t.Item2, t.Item2))) //If we cross only add the cost from the start to the point not the full ray
                    {
                        if(!segment.flipped) //Make sure we find the distance from the right side of the ray
                            w1+= Helpers.ManhattanDist(new Tuple<int, int>(segment.startX,segment.startY),t);
                        else 
                            w1+= Helpers.ManhattanDist(new Tuple<int, int>(segment.stopX,segment.stopY),t);
                        break; //stop 
                    } else //if we haven't found the crossing, add the full cost
                        w1+= Helpers.ManhattanDist(new Tuple<int, int>(segment.startX,segment.startY),new Tuple<int, int>(segment.stopX,segment.stopY));
                }

                foreach(ray segment in Wire2) //same thing just for the second wire
                {
                    if (segment.Crosses(new ray(t.Item1, t.Item1, t.Item2, t.Item2)))
                    {
                        if(!segment.flipped)
                            w2+= Helpers.ManhattanDist(new Tuple<int, int>(segment.startX,segment.startY),t);
                        else 
                            w2+= Helpers.ManhattanDist(new Tuple<int, int>(segment.stopX,segment.stopY),t);
                        break;
                    }else 
                        w2+= Helpers.ManhattanDist(new Tuple<int, int>(segment.startX,segment.startY),new Tuple<int, int>(segment.stopX,segment.stopY));
                }

                sumCost.Add(w1 + w2);

            }

            //find the minimum cost
            int minCost = 99999999;
            foreach (int i in sumCost)
                if (i < minCost)
                    minCost = i;


            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            // Bragging rights until Billy gets gud
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("min cost: " + minCost);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();


        }
    }
}

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
            List<String> strIn = Helpers.readToStringList(11);
            List<TravelingPoint> points = new List<TravelingPoint>();

            foreach (string str in strIn)
                points.Add(new TravelingPoint(str));


            //Find top most and bottom most points
            int minDis = MaxDist(points);
            int steps = 0;
            while (true)
            {
                steps++;
                foreach (TravelingPoint tp in points)
                    tp.step();

                int newMax = MaxDist(points);
                if (minDis > newMax)
                    minDis = newMax;
                else
                {
                    Console.WriteLine(steps-1);
                    Console.WriteLine();
                    foreach (TravelingPoint tp in points)
                        tp.stepBack();

                    int leftMin = leftMost(points);
                    int bottomMin = bottomMost(points);
                    int topMax = topMost(points);
                    int rightMax = rightMost(points);

                    int width = rightMost(points) - leftMost(points)+1;
                    int height = topMost(points) - bottomMost(points)+1;
                    bool[,] grid = new bool[width, height];


                    foreach(TravelingPoint tp in points)
                    {
                        grid[tp.pX - leftMin, tp.pY - bottomMin] = true;
                    }

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            if (grid[j, i])
                                Console.Write('*');
                            else
                                Console.Write(' ');
                        }
                        Console.WriteLine();
                    }

                    break;
                    //draw grid
                }
                        
                        
                



            }


            Console.ReadLine();

        }

        private static int MaxDist(List<TravelingPoint> points)
        {
            int top = topMost(points);
            int bottom = bottomMost(points);

            return top - bottom;
        }

        private static int leftMost(List<TravelingPoint> points)
        {
            int left = 9999999;
            foreach (TravelingPoint p in points)
                if (p.pX < left)
                    left = p.pX;
            return left;
        }
        private static int rightMost(List<TravelingPoint> points)
        {
            int right = 0;
            foreach (TravelingPoint p in points)
                if (p.pX > right)
                    right = p.pX;
            return right;
        }
        private static int topMost(List<TravelingPoint> points)
        {
            int top = 0;
            foreach (TravelingPoint p in points)
                if (p.pY > top)
                    top = p.pY;
            return top;
        }
        private static int bottomMost(List<TravelingPoint> points)
        {
            int bottom = 9999999;
            foreach (TravelingPoint p in points)
                if (p.pY < bottom)
                    bottom = p.pY;
            return bottom;
        }
    }

    public class TravelingPoint {
        public int pX, pY, vX, vY;

        public TravelingPoint(String strIn)
        {
            string[] parts = strIn.Split('>');
            pX = int.Parse(parts[0].Split('<')[1].Split(',')[0]);
            pY = int.Parse(parts[0].Split('<')[1].Split(',')[1]);

            vX = int.Parse(parts[1].Split('<')[1].Split(',')[0]);
            vY = int.Parse(parts[1].Split('<')[1].Split(',')[1]);


        }

        public void step()
        {
            pX += vX;
            pY += vY;
        }

        public void stepBack()
        {
            pX -= vX;
            pY -= vY;
        }

    }
}

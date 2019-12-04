using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{
    class ray
    {

        //A ray will represent a segment of wire 
        public int startX { get; set; }
        public int startY { get; set; }
        public int stopX { get; set; }
        public int stopY { get; set; }

        public bool flipped { get; set; }

        public ray(int startX, int stopX, int startY, int stopY)
        {
            flipped = false;

            //Keeping the start value always down and to the left makes finding intersections easier. I think
            //Judging from how much it took to debug, probably not
            if (startX <= stopX) { 
                this.startX = startX;
                this.stopX = stopX;
            } else
            {
                flipped = true;
                this.stopX = startX;
                this.startX = stopX;

            }
            if (startY <= stopY)
            {
                this.startY = startY;
                this.stopY = stopY;
            } else
            {
                flipped = true;
                this.stopY = startY;
                this.startY = stopY;

            }

        }



        //Checks for an intersection between this ray and the passed ray
        //This is apparently broken commiting so i can revert if necessary.
        //Okay, fixed it. In the spirit of full disclosure I try to never use google for these.. but I guess the purpose is to learn
        // http://jeffreythompson.org/collision-detection/line-line.php
        public bool Crosses(ray r)
            { 
                float denominator = ((stopX - startX) * (r.stopY - r.startY)) - ((stopY - startY) * (r.stopX - r.startX));
                float numerator1 = ((startY - r.startY) * (r.stopX - r.startX)) - ((startX - r.startX) * (r.stopY - r.startY));
                float numerator2 = ((startY - r.startY) * (stopX - startX)) - ((startX - r.startX) * (stopY - startY));

                if (denominator == 0) 
                    return numerator1 == 0 && numerator2 == 0;
                float x = numerator1 / denominator;
                float y = numerator2 / denominator;
                return (x >= 0 && x <= 1) && (y >= 0 && y <= 1);

            }

        //finds the specific point of intersection
        // slower than finding a general crossing so only use if you've found a crossing
        public List<Tuple<int,int>> findIntersections(ray r)
        {
            List<Tuple<int,int>> Lout = new List<Tuple<int, int>>();
            for(int i = r.startX; i <= r.stopX; i++)
            {
                for(int j = r.startY; j <= r.stopY; j++)
                {
                    if (this.startX <= i && this.stopX >= i && this.startY <= j && this.stopY >= j)
                        Lout.Add(new Tuple<int, int>(i, j));

                }
            }
            return Lout;
        }
    }
}

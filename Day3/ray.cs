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
        public bool Crosses(ray r)
        {
            if (this.startX <= r.startX && this.stopX >= r.stopX && this.startY <= r.startY && this.stopY >= r.stopY)
                return true;
            return false;
        }

        //finds the specific point of intersection
        //
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

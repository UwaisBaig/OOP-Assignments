using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___1_points_x_y
{
    public class MyLine
    {
        private MyPoint begin;
        private MyPoint end;

        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;
        }
        public MyPoint getBegin()
        {
            return begin;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }

        public MyPoint getEnd()
        {
            return end;
        }
        public void setEnd(MyPoint end)
        {
            this.end = end;
        }        
        public double getLength()
        {
            return begin.distanceWithObject(end);
        }

        
        public double getGradient()
        {
            int xDiff = end.getX() - begin.getX();
            int yDiff = end.getY() - begin.getY();

            if (xDiff == 0)
                return double.PositiveInfinity;

            return (double)yDiff / xDiff;
        }
    }
}
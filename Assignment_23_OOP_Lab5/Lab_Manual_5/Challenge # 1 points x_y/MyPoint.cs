using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___1_points_x_y
{
    public class MyPoint
    {
        private int x;
        private int y;

        //default constructor at(0,0)
        public MyPoint()
        {
            this.x = 0;
            this.y = 0;
        }

        // Parameterized constructor
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Getters and Setters
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // distance specify here:
        public double distanceWithCords(int x, int y)
        {
            return Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2));
        }

        //distance to other MyPoint object
        public double distanceWithObject(MyPoint another)
        {
            return Math.Sqrt(Math.Pow(this.x - another.getX(), 2) + Math.Pow(this.y - another.getY(), 2));
        }

        //distance from origin
        public double distanceFromZero()
        {
            return distanceWithCords(0, 0);
        }
    }
}
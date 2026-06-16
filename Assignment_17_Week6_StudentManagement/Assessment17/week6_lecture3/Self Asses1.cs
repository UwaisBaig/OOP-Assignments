using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MyPoint
{
    private int x;
    private int y;

    public MyPoint()
    {
        this.x = 0;
        this.y = 0;
    }

    public MyPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }

    public bool setX(int x)
    {
        this.x = x;
        return true;
    }

    public int getY()
    {
        return y;
    }

    public bool setY(int y)
    {
        this.y = y;
        return true;
    }

    public bool setXY(int x, int y)
    {
        this.x = x;
        this.y = y;
        return true;
    }

    public int distance(int x, int y)
    {
        int diffX = this.x - x;
        int diffY = this.y - y;
        return (int)Math.Sqrt(diffX * diffX + diffY * diffY);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MathOperations
{
    public static int Square(int num)
    {
        return num * num;
    }

    public static double Square(double num)
    {
        return num * num;
    }
}

class Program
{
    static void Main()
    {
        // Execution
        double result1 = MathOperations.Square(5);
        double result2 = MathOperations.Square(3.5);

        MathOperations math = new MathOperations();
        double result3 = MathOperations.Square(3.5);
    }
}
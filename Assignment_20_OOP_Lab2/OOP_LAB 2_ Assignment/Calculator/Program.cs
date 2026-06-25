using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_task
{
    class Calculator
    {
        public int Number1;
        public int Number2;

        public Calculator(int n1, int n2)
        {
            Number1 = n1;
            Number2 = n2;
        }
        public void Add()
        {
            int res = Number1 + Number2;
            Console.WriteLine("Addition: " + res);
        }
        public void Subtract()
        {
            int res = Number1 - Number2;
            Console.WriteLine("Subtraction: " + res);
        }
        public void Multiply()
        {
            int res = Number1 * Number2;
            Console.WriteLine("Multiplication: " + res);
        }
        public void Divide()
        {
            int res = Number1 / Number2;
            Console.WriteLine("Division: " + res);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator(20, 10);
            calc.Add();
            calc.Subtract();
            calc.Multiply();
            calc.Divide();
        }
    }
}

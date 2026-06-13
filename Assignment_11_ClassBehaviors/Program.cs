
// in this assignment we will learn about to combine the data(attributes) and related fuctions but in the same class .





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructor_assignment_of_week_3
{
    class circle
    {
        public string color;
        public double radius;
        public circle()                            // default constructor
        {
            color = "red";
            radius = 1.0;
        }
        public circle(double rad)                         // parameterized constructor
        {
            radius = rad;
        }
        public circle(string col, double rad)           // parameterized constructor
        {
            color = col;
            radius = rad;
        }
        public circle(circle c)                     // copy constructor
        {
            radius = c.radius;
            color = c.color;
        }
        public double getArea()
        {
            double area =3.1467F* radius*radius;
            return area;
        }
        public double getDiameter()
        {
            return 2 * radius * 1.0F;
        }
        public double getCircumference()
        {
            return 2 * 3.1467F * radius;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            circle c1 = new circle();
            Console.WriteLine("Radius of circle c1 is" + c1.radius + "\n color of circle c1 is " + c1.color );
            double area=c1.getArea();
            double diameter = c1.getDiameter();
            double circumference = c1.getCircumference();
            Console.WriteLine("Area of circle c1 is" +area  + "\n circumference of c1 is "+circumference+"\nDiameter of circle c1 is "+diameter);
            circle c2 = new circle(2.36);
            Console.WriteLine("Radius of circle c2 is" + c2.radius + "\n color of circle c2 is " + c2.color);
             area = c2.getArea();
             diameter = c2.getDiameter();
             circumference = c2.getCircumference();
            Console.WriteLine("Area of circle c2 is" + area + "\n circumference of c2 is " + circumference + "\nDiameter of circle c2 is " + diameter);
            circle c3 = new circle("blue", 3.314);
            Console.WriteLine("Radius of circle c3 is" + c3.radius + "\n color of circle c3 is " + c3.color);
            area = c3.getArea();
            diameter = c3.getDiameter();
            circumference = c3.getCircumference();
            Console.WriteLine("Area of circle c3 is" + area + "\n circumference of c3 is " + circumference + "\nDiameter of circle c3 is " + diameter);
            circle c4 = new circle(c1);
            Console.WriteLine("Radius of circle c4 is" + c4.radius + "\n color of circle c4 is " + c4.color);
            area = c4.getArea();
            diameter = c4.getDiameter();
            circumference = c4.getCircumference();
            Console.WriteLine("Area of circle c4 is" + area + "\n circumference of c4 is " + circumference + "\nDiameter of circle c4 is " + diameter);
            Console.ReadKey();
        }
    }
}

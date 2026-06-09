using System;

public class Circle
{
    private double radius;
    private string color;

    public Circle()
    {
        this.radius = 1.0;
        this.color = "red";
    }

    public Circle(double radius)
    {
        this.radius = radius;
        this.color = "red"; 
    }

   
    public Circle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }

    
    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Circle -> Radius: {radius}, Color: {color}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Testing the Circle class constructors:\n");

        Circle c1 = new Circle();
        Console.Write("Constructor 1 (Default): ");
        c1.DisplayInfo();

        
        Circle c2 = new Circle(5.5);
        Console.Write("Constructor 2 (Radius only): ");
        c2.DisplayInfo();

        Circle c3 = new Circle(2.5, "blue");
        Console.Write("Constructor 3 (Radius and Color): ");
        c3.DisplayInfo();



    }
}
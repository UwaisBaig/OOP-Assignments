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

    public Circle(Circle sourceObj)
    {
        this.radius = sourceObj.radius;
        this.color = sourceObj.color;
    }

    public double Radius { get { return radius; } set { radius = value; } }
    public string Color { get { return color; } set { color = value; } }

    public void DisplayInfo()
    {
        Console.WriteLine($"Radius: {radius}, Color: {color}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Testing the Circle Class ---");

        Circle c1 = new Circle();
        Console.Write("Constructor 1 (Default): ");
        c1.DisplayInfo();

        Circle c2 = new Circle(5.5);
        Console.Write("Constructor 2 (Radius only): ");
        c2.DisplayInfo();

        Circle c3 = new Circle(2.5, "blue");
        Console.Write("Constructor 3 (Radius & Color): ");
        c3.DisplayInfo();

        Circle copiedCircle = new Circle(c3);
        Console.Write("Copy Constructor (Copied from C3): ");
        copiedCircle.DisplayInfo();

        copiedCircle.Color = "green";
        Console.WriteLine("\n--- After changing the copy's color to green ---");
        Console.Write("Original C3: "); c3.DisplayInfo();
        Console.Write("Copied Circle: "); copiedCircle.DisplayInfo();
    }
}
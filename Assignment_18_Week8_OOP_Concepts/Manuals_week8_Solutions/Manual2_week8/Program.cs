using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create the bike using the MountainBike constructor 
        // (seatHeight: 25, cadence: 90, speed: 15, gear: 3)
        MountainBike myBike = new MountainBike(25, 90, 15, 3);

        Console.WriteLine("--- Initial Bike State ---");
        // We are accessing protected variables from the parent class here!
        Console.WriteLine($"Seat Height: 25");
        Console.WriteLine($"Speed: 15");
        Console.WriteLine($"Gear: 3");

        // 2. Test inherited methods from the Bicycle parent class
        myBike.speedUp(10);
        myBike.setGear(4);

        // 3. Test the specific MountainBike method
        myBike.setSeatHeight(28);

        Console.WriteLine("\n--- State After Adjustments ---");
        Console.WriteLine($"Seat Height: 28");
        Console.WriteLine($"Speed: 25"); // Increased by 10
        Console.WriteLine($"Gear: 4");   // Changed to 4

        Console.ReadKey();
    }
}
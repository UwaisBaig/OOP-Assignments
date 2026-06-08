using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. View all customers");
            Console.WriteLine("3. Check Pizza Points eligibility");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();

                Console.Write("Enter number of orders: ");
                int numOrders = int.Parse(Console.ReadLine());

                string prices = "";
                for (int i = 0; i < numOrders; i++)
                {
                    Console.Write("Enter price for order " + (i + 1) + ": ");
                    prices += Console.ReadLine();
                    if (i < numOrders - 1)
                    {
                        prices += ",";
                    }
                }

                string line = name + " " + numOrders + " [" + prices + "]\n";
                File.AppendAllText("Customers.txt", line);
                Console.WriteLine("Customer added.");
            }
            else if (choice == "2")
            {
                if (File.Exists("Customers.txt"))
                {
                    string[] lines = File.ReadAllLines("Customers.txt");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("No customers found.");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter minimum number of orders (N): ");
                int N = int.Parse(Console.ReadLine());

                Console.Write("Enter minimum order price (Y): ");
                int Y = int.Parse(Console.ReadLine());

                pizza_points(N, Y);
            }
            else if (choice == "4")
            {
                break;
            }

            Console.WriteLine();
        }
    }

    static void pizza_points(int N, int Y)
    {
        if (!File.Exists("Customers.txt"))
        {
            Console.WriteLine("\"\"");
            return;
        }

        string[] lines = File.ReadAllLines("Customers.txt");
        bool found = false;

        foreach (string line in lines)
        {
            if (line.Trim() == "")
            {
                continue;
            }

            string[] parts = line.Split(' ');
            string name = parts[0];

            string pricesString = parts[2].Replace("[", "").Replace("]", "");
            string[] priceList = pricesString.Split(',');

            int validOrders = 0;

            foreach (string priceItem in priceList)
            {
                int price = int.Parse(priceItem);
                if (price >= Y)
                {
                    validOrders++;
                }
            }

            if (validOrders >= N)
            {
                Console.WriteLine("\"" + name + "\"");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("\"\"");
        }
    }
}
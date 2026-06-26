using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02_Smart_Product_Store_Simulation
{
    public class Product
    {
        public string Name;
        public double Price;
        public int Stock;
        public double TaxRate;
        public Product(string name, double price, int stock, double taxRate)
        {
            Name = name;
            Price = price;
            Stock = stock;
            TaxRate = taxRate;
        }
        public double CalculateTax()
        {
            return Price * TaxRate;
        }
    }
    public class StoreUI
    {
        public static string GetValidName(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    return input;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static double GetValidDouble(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double value) && value >= 0)
                {
                    return value;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static int GetValidInt(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= 0)
                {
                    return value;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- STORE SYSTEM STARTED ---\n");
            List<Product> store = new List<Product>();

            for (int i = 1; i <= 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nEnter details for Product {i}:");
                string name = StoreUI.GetValidName("Enter Product Name: ");
                double price = StoreUI.GetValidDouble("Enter Product Price: ");
                int stock = StoreUI.GetValidInt("Enter Product Stock: ");
                double tax = StoreUI.GetValidDouble("Enter Tax Rate (e.g., 0.1 for 10%): ");
                store.Add(new Product(name, price, stock, tax));
                Console.WriteLine("Product Added Successfully!");
            }
            Console.Clear();
            Console.WriteLine("--- STORE REPORT ---\n");
            double totalStoreTax = 0;
            Product mostExpensive = null;

            foreach (var p in store)
            {
                if (p.Stock > 0)
                {
                    totalStoreTax += p.CalculateTax();

                    if (mostExpensive == null || p.Price > mostExpensive.Price)
                    {
                        mostExpensive = p;
                    }
                }
            }
            Console.WriteLine($"Total Store Tax: {totalStoreTax}\n");
            Console.WriteLine("Low Stock Products (Less than 10):");
            bool foundLowStock = false;
            foreach (var p in store)
            {
                if (p.Stock > 0 && p.Stock < 10)
                {
                    Console.WriteLine($"- {p.Name} (Stock: {p.Stock})");
                    foundLowStock = true;
                }
            }
            if (!foundLowStock)
                Console.WriteLine("- No low stock products.");
            Console.WriteLine("\nMost Expensive Product:");
            if (mostExpensive != null)
            {
                Console.WriteLine($"- {mostExpensive.Name} -> Price: {mostExpensive.Price}");
            }
            else
            {
                Console.WriteLine("- No valid products in stock.");
            }
            Console.WriteLine("\n--- STORE REPORT GENERATED ---");
            Console.ReadLine();
        }
    }
}
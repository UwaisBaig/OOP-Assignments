using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_MS_atsk
{
    class Product
    {
        public int ID;
        public string Name;
        public double Price;
        public string Category;
        public string Brand;
        public string Country;
        public Product(int id, string n, double p, string c, string b, string count)
        {
            ID = id;
            Name = n;
            Price = p;
            Category = c;
            Brand = b;
            Country = count;
        }
    }
    class Program
    {
        static Product[] store = new Product[20];
        static int productCount = 0;

        static void Main(string[] args)
        {
            AddProduct(101, "Laptop", 50000, "Electronics", "HP", "USA");
            AddProduct(102, "Mobile", 30000, "Electronics", "Samsung", "Korea");
            Console.WriteLine("--- Default items loaded! ---");
            Console.Write("\nDo you want to add more products? (yes/no): ");
            string ans = Console.ReadLine();
            if (ans == "yes")
            {
                Console.Write("How many more? ");
                int more = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < more; i++)
                {
                    Console.WriteLine($"\nEnter Details for Product {i + 1}:");
                    AddFromUser();
                }
            }            
            ShowProducts();
            TotalStoreWorth();
        }
        static void AddProduct(int id, string n, double p, string c, string b, string count)
        {
            store[productCount] = new Product(id, n, p, c, b, count);
            productCount++;
        }
        static void AddFromUser()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Category: ");
            string cat = Console.ReadLine();
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Country: ");
            string country = Console.ReadLine();

            AddProduct(id, name, price, cat, brand, country);
        }
        static void ShowProducts()
        {
            Console.WriteLine("\n--- Final Product List ---");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"ID: {store[i].ID} | Name: {store[i].Name} | Price: {store[i].Price}");
            }
        }
        static void TotalStoreWorth()
        {
            double total = 0;
            for (int i = 0; i < productCount; i++)
            {
                total = total + store[i].Price;
            }
            Console.WriteLine("\nTotal Store Worth: " + total);
        }
    }
}

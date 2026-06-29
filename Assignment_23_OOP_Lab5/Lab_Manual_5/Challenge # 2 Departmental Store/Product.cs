using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___2_Departmental_Store
{
    // --- BUSINESS LOGIC ---
    public class Product
    {
        public string name;
        public string category;
        public double price;
        public int stock;
        public int threshold;

        public Product(string name, string category, double price, int stock, int threshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stock = stock;
            this.threshold = threshold;
        }

        // Calculates tax based on category rules
        public double calculateTax()
        {
            if (category.ToLower() == "grocery")
                return price * 0.10;
            else if (category.ToLower() == "fruit")
                return price * 0.05;
            else
                return price * 0.15;
        }
    }

    // --- DATA LAYER ---
    public class ProductDL
    {
        public static List<Product> products = new List<Product>();

        public static void addProduct(Product p)
        {
            products.Add(p);
        }

        public static Product getHighestPricedProduct()
        {
            if (products.Count == 0) return null;

            Product highest = products[0];
            foreach (Product p in products)
            {
                if (p.price > highest.price)
                    highest = p;
            }
            return highest;
        }

        public static Product searchProduct(string name)
        {
            foreach (Product p in products)
            {
                if (p.name.ToLower() == name.ToLower()) return p;
            }
            return null;
        }
    }

    // --- USER INTERFACE ---
    public class ProductUI
    {
        public static Product takeInput()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category (Grocery/Fruit/Other): ");
            string category = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter Minimum Threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            return new Product(name, category, price, stock, threshold);
        }

        public static void showProduct(Product p)
        {
            Console.WriteLine($"Name: {p.name} | Category: {p.category} | Price: Rs.{p.price} | Stock: {p.stock}");
        }

        public static void showTax(Product p)
        {
            Console.WriteLine($"Name: {p.name} | Base Price: Rs.{p.price} | Sales Tax: Rs.{p.calculateTax():F2}");
        }
    }
}
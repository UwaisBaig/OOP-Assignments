using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_manuak_4__23_4_26_
{

    internal class Program
    {
        class Product
        {
            public string name;
            public float price;
            public float tax()
            {
                return price * 0.1f;
            }
        }

        class Customer
        {
            public string name; 
            public List<Product> products = new List<Product>();
        
            public void addProduct(Product p)
            {
                products.Add(p);
            }
        
        }

        static void Main(string[] args)
        {
           Customer c = new Customer();
            c.name = "Ali";

            Product p1 = new Product();
            p1.name = "Milk";
            p1.price = 100;

            Product p2 = new Product();
            p2.name = "Bread";
            p2.price = 80;

            c.addProduct(p1);
            c.addProduct(p2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___2_Departmental_Store
{
    // --- BUSINESS LOGIC ---
    public class Customer
    {
        // Parallel lists to keep track of what the customer is buying
        public List<Product> cartProducts = new List<Product>();
        public List<int> cartQuantities = new List<int>();

        public void buyProduct(Product p, int amount)
        {
            cartProducts.Add(p);
            cartQuantities.Add(amount);
            p.stock -= amount; // Decrease from global stock
        }

        public double calculateInvoiceTotal()
        {
            double total = 0;
            for (int i = 0; i < cartProducts.Count; i++)
            {
                Product p = cartProducts[i];
                int qty = cartQuantities[i];
                double tax = p.calculateTax();
                total += (p.price + tax) * qty;
            }
            return total;
        }
    }

    // --- USER INTERFACE ---
    public class CustomerUI
    {
        public static void printInvoice(Customer c)
        {
            Console.WriteLine("\n--- Customer Invoice ---");
            Console.WriteLine("Item \t Qty \t Base Price \t Tax \t Total");

            for (int i = 0; i < c.cartProducts.Count; i++)
            {
                Product p = c.cartProducts[i];
                int qty = c.cartQuantities[i];
                double tax = p.calculateTax();
                double subTotal = (p.price + tax) * qty;

                Console.WriteLine($"{p.name} \t {qty} \t Rs.{p.price} \t Rs.{tax:F2} \t Rs.{subTotal:F2}");
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Grand Total: Rs.{c.calculateInvoiceTotal():F2}\n");
        }
    }
}
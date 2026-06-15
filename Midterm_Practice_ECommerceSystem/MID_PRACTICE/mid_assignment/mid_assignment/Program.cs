using System;
using StoreSystem.BL;
using StoreSystem.DL;
using StoreSystem.UI;

namespace StoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int orderCounter = 1;

            // 1. Add 3 Products in the system
            Product p1 = new Product(101, "Laptop", 1000f);
            Product p2 = new Product(102, "Mouse", 25f);
            Product p3 = new Product(103, "Keyboard", 45f);

            StoreDL.AddProduct(p1);
            StoreDL.AddProduct(p2);
            StoreDL.AddProduct(p3);

            // 2. Add 2 Customers in the system
            ShoppingCart cart1 = new ShoppingCart(1, "Red");
            Customer c1 = new Customer(1, "Alice", "pass123", cart1);

            ShoppingCart cart2 = new ShoppingCart(2, "Blue");
            Customer c2 = new Customer(2, "Bob", "pass456", cart2);

            StoreDL.AddCustomer(c1);
            StoreDL.AddCustomer(c2);

            // --- PURCHASE 1 ---
            // 1st customer buys last two products entered (p2, p3)
            c1.Cart.AddItem(p2);
            c1.Cart.AddItem(p3);

            float purchase1Total = c1.Cart.GetTotalPrice();
            Order order1 = new Order(orderCounter++, purchase1Total);
            c1.AddOrder(order1);
            StoreDL.RecordOrder(order1);
            c1.Cart.ClearCart(); // Empty cart after checkout
            StoreUI.DisplayMessage($"Customer 1 (Alice) bought {p2.Name} & {p3.Name}. Total: ${purchase1Total}");

            // --- PURCHASE 2 ---
            // 2nd customer buys first two products entered (p1, p2)
            c2.Cart.AddItem(p1);
            c2.Cart.AddItem(p2);

            float purchase2Total = c2.Cart.GetTotalPrice();
            Order order2 = new Order(orderCounter++, purchase2Total);
            c2.AddOrder(order2);
            StoreDL.RecordOrder(order2);
            c2.Cart.ClearCart();
            StoreUI.DisplayMessage($"Customer 2 (Bob) bought {p1.Name} & {p2.Name}. Total: ${purchase2Total}");

            // --- PURCHASE 3 ---
            // 1st customer again buys 1st and 3rd product (p1, p3)
            c1.Cart.AddItem(p1);
            c1.Cart.AddItem(p3);

            float purchase3Total = c1.Cart.GetTotalPrice();
            Order order3 = new Order(orderCounter++, purchase3Total);
            c1.AddOrder(order3);
            StoreDL.RecordOrder(order3);
            c1.Cart.ClearCart();
            StoreUI.DisplayMessage($"Customer 1 (Alice) bought {p1.Name} & {p3.Name}. Total: ${purchase3Total}");

            // --- CALCULATE GRAND TOTAL ---
            // Show the total amount of all 3 purchases that both customers have done.
            float grandTotal = 0;
            foreach (Order o in StoreDL.MasterOrderList)
            {
                grandTotal += o.TotalAmount;
            }

            StoreUI.DisplayTotalSales(grandTotal);

            Console.ReadLine();
        }
    }
}
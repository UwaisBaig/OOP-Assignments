using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___2_Departmental_Store
{
    class Program
    {
        static void Main()
        {
            // Adding a default admin to make testing easier
            MUserDL.addUser(new MUser("admin", "123", "Admin"));

            int mainOption;
            do
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. SignIn");
                Console.WriteLine("2. SignUp");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");
                if (!int.TryParse(Console.ReadLine(), out mainOption)) continue;

                if (mainOption == 1)
                {
                    MUser loginAttempt = MUserUI.takeLoginInput();
                    MUser validUser = MUserDL.signIn(loginAttempt.username, loginAttempt.password);

                    if (validUser != null)
                    {
                        if (validUser.role.ToLower() == "admin")
                        {
                            AdminMenu();
                        }
                        else
                        {
                            CustomerMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials!");
                    }
                }
                else if (mainOption == 2)
                {
                    MUser newUser = MUserUI.takeInput();
                    MUserDL.addUser(newUser);
                    Console.WriteLine("User Registered Successfully!");
                }

            } while (mainOption != 3);
        }

        static void AdminMenu()
        {
            int option;
            do
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Find Product with Highest Unit Price");
                Console.WriteLine("4. View Sales Tax of All Products");
                Console.WriteLine("5. Products to be Ordered (less than threshold)");
                Console.WriteLine("6. Logout");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out option)) continue;

                if (option == 1)
                {
                    Product p = ProductUI.takeInput();
                    ProductDL.addProduct(p);
                    Console.WriteLine("Product added successfully!");
                }
                else if (option == 2)
                {
                    foreach (Product p in ProductDL.products)
                        ProductUI.showProduct(p);
                }
                else if (option == 3)
                {
                    Product highest = ProductDL.getHighestPricedProduct();
                    if (highest != null)
                    {
                        Console.WriteLine("Highest Priced Product:");
                        ProductUI.showProduct(highest);
                    }
                }
                else if (option == 4)
                {
                    foreach (Product p in ProductDL.products)
                        ProductUI.showTax(p);
                }
                else if (option == 5)
                {
                    Console.WriteLine("--- Needs Reordering ---");
                    foreach (Product p in ProductDL.products)
                    {
                        if (p.stock < p.threshold)
                            ProductUI.showProduct(p);
                    }
                }
            } while (option != 6);
        }

        static void CustomerMenu()
        {
            int option;
            Customer currentCustomer = new Customer(); // Create a new cart for this session

            do
            {
                Console.WriteLine("\n--- Customer Menu ---");
                Console.WriteLine("1. View all the products");
                Console.WriteLine("2. Buy a product");
                Console.WriteLine("3. Generate invoice");
                Console.WriteLine("4. Logout");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out option)) continue;

                if (option == 1)
                {
                    foreach (Product p in ProductDL.products)
                        ProductUI.showProduct(p);
                }
                else if (option == 2)
                {
                    Console.Write("Enter the name of the product you want to buy: ");
                    string name = Console.ReadLine();
                    Product found = ProductDL.searchProduct(name);

                    if (found != null)
                    {
                        Console.Write("Enter quantity to buy: ");
                        int qty = int.Parse(Console.ReadLine());

                        if (found.stock >= qty)
                        {
                            currentCustomer.buyProduct(found, qty);
                            Console.WriteLine("Added to cart successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient stock! Only {found.stock} left.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
                else if (option == 3)
                {
                    CustomerUI.printInvoice(currentCustomer);
                }
            } while (option != 4);
        }
    }
}
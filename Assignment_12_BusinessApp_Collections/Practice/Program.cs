using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sign_Up_CRUD_class_17_March
{
    class MUser
    {
        public string Username, Password, Role;
        public MUser(string u, string p, string r) { Username = u; Password = p; Role = r; }
    }

    class Product
    {
        public string Name;
        public double Price;
        public int Stock;
        public Product(string n, double p, int s) { Name = n; Price = p; Stock = s; }
    }

    class Program
    { 
        static List<MUser> users = new List<MUser>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            LoadUsers();
            LoadProducts();

            string choice = "";
            while (choice != "3")
            {
                Console.Clear();
                Console.WriteLine("=== WELCOME TO BUSINESS APP ===");
                Console.WriteLine("1. Login\n2. Register\n3. Exit");
                Console.Write("Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Login(); break;
                    case "2": Register(); break;
                }
            }
        }

        static void Register()
        {
            Console.Write("Username: "); string u = Console.ReadLine();
            Console.Write("Password: "); string p = Console.ReadLine();
            Console.Write("Role (Admin/User): "); string r = Console.ReadLine();

            users.Add(new MUser(u, p, r));
            SaveUsers();

            Console.WriteLine("Registered! Press any key..."); Console.ReadKey();
        }

        static void Login()
        {
            Console.Write("Username: "); string u = Console.ReadLine();
            Console.Write("Password: "); string p = Console.ReadLine();

            
            MUser activeUser = users.Find(user => user.Username == u && user.Password == p);

            if (activeUser != null)
            {
                if (activeUser.Role.ToLower() == "admin") AdminMenu();
                else UserMenu();
            }
            else
            {
                Console.WriteLine("Invalid Login! Press any key..."); Console.ReadKey();
            }
        }

        static void AdminMenu()
        {
            string op = "";
            while (op != "5")
            {
                Console.Clear();
                Console.WriteLine("--- ADMIN PANEL (CRUD) ---");
                Console.WriteLine("1. Add Product\n2. View Products\n3. Update Product\n4. Delete Product\n5. Logout");
                Console.Write("Select: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.Write("Name: "); string n = Console.ReadLine();
                        Console.Write("Price: "); double p = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Stock: "); int s = Convert.ToInt32(Console.ReadLine());
                        products.Add(new Product(n, p, s));
                        SaveProducts();
                        break;
                    case "2":
                        ShowTable();
                        break;
                    case "3":
                        ShowTable();
                        Console.Write("Enter product index to update: ");
                        int updateIdx = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New Price: ");
                        products[updateIdx].Price = Convert.ToDouble(Console.ReadLine());
                        SaveProducts();
                        break;
                    case "4":
                        ShowTable();
                        Console.Write("Enter index to delete: ");
                        int delIdx = Convert.ToInt32(Console.ReadLine());
                        products.RemoveAt(delIdx); 
                        SaveProducts();
                        break;
                }
            }
        }

        static void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("--- USER PANEL ---");
            ShowTable();
        }

        static void ShowTable()
        {
            Console.WriteLine("\n{0,-5} {1,-15} {2,-10} {3,-10}", "Idx", "Name", "Price", "Stock");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-10} {3,-10}", i, products[i].Name, products[i].Price, products[i].Stock);
            }
            Console.WriteLine("\nPress any key..."); Console.ReadKey();
        }

        static void SaveUsers()
        {
            var lines = users.Select(u => $"{u.Username},{u.Password},{u.Role}");
            File.WriteAllLines("users.txt", lines);
        }

        static void LoadUsers()
        {
            if (File.Exists("users.txt"))
            {
                foreach (var line in File.ReadAllLines("users.txt"))
                {
                    string[] d = line.Split(',');
                    users.Add(new MUser(d[0], d[1], d[2]));
                }
            }
        }

        static void SaveProducts()
        {
            var lines = products.Select(p => $"{p.Name},{p.Price},{p.Stock}");
            File.WriteAllLines("products.txt", lines);
        }

        static void LoadProducts()
        {
            if (File.Exists("products.txt"))
            {
                foreach (var line in File.ReadAllLines("products.txt"))
                {
                    string[] d = line.Split(',');
                    products.Add(new Product(d[0], Convert.ToDouble(d[1]), Convert.ToInt32(d[2])));
                }
            }
        }
    }
}
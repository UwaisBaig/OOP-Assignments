using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_9
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
        static MUser[] users = new MUser[50];
        static Product[] products = new Product[50];
        static int userCount = 0, productCount = 0;
        static void Main(string[] args)
        {
            LoadUsers(); LoadProducts();
            string choice = "";
            while (choice != "3")
            {
                Console.Clear();
                Console.WriteLine("=== WELCOME TO BUSINESS APP ===");
                Console.WriteLine("1. Login\n2. Register\n3. Exit");
                Console.Write("Choice: "); choice = Console.ReadLine();
                if (choice == "1")
                    Login();
                else if (choice == "2")
                    Register();
            }
        }
        static void Register()
        {
            Console.Write("Username: "); string u = Console.ReadLine();
            Console.Write("Password: "); string p = Console.ReadLine();
            Console.Write("Role (Admin/User): "); string r = Console.ReadLine();
            users[userCount++] = new MUser(u, p, r);
            SaveUsers();
            Console.WriteLine("Registered! Press any key..."); Console.ReadKey();
        }
        static void Login()
        {
            Console.Write("Username: ");
            string u = Console.ReadLine();
            Console.Write("Password: ");
            string p = Console.ReadLine();
            MUser activeUser = null;
            for (int i = 0; i < userCount; i++)
            {
                if (users[i].Username == u && users[i].Password == p) activeUser = users[i];
            }
            if (activeUser != null)
            {
                if (activeUser.Role.ToLower() == "admin")
                    AdminMenu();
                else
                    UserMenu();
            }
            else
            {
                Console.WriteLine("Invalid Login!"); Console.ReadKey();
            }
        }
        static void AdminMenu()
        {
            string op = "";
            while (op != "5")
            {
                Console.Clear();
                Console.WriteLine("--- ADMIN PANEL (CRUD) ---");
                Console.WriteLine("1. Add Product (Create)\n2. View Products (Read)\n3. Update Product (Update)\n4. Delete Product (Delete)\n5. Logout");
                Console.Write("Select: "); op = Console.ReadLine();

                if (op == "1")
                {
                    Console.Write("Name: ");
                    string n = Console.ReadLine();
                    Console.Write("Price: ");
                    double p = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Stock: ");
                    int s = Convert.ToInt32(Console.ReadLine());
                    products[productCount++] = new Product(n, p, s);
                    SaveProducts();
                }
                else if (op == "2")
                    ShowTable();
                else if (op == "3")
                {
                    ShowTable();
                    Console.Write("Enter product index to update: ");
                    int idx = Convert.ToInt32(Console.ReadLine());
                    Console.Write("New Price: ");
                    products[idx].Price = Convert.ToDouble(Console.ReadLine());
                    SaveProducts();
                }
                else if (op == "4")
                {
                    ShowTable();
                    Console.Write("Enter index to delete: ");
                    int idx = Convert.ToInt32(Console.ReadLine());
                    for (int i = idx; i < productCount - 1; i++)
                        products[i] = products[i + 1];
                    productCount--; SaveProducts();
                }
            }
        }
        static void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("--- USER PANEL ---");
            ShowTable();
            Console.WriteLine("Press any key to logout..."); Console.ReadKey();
        }
        static void ShowTable()
        {
            Console.WriteLine("{0,-5} {1,-15} {2,-10} {3,-10}", "Idx", "Name", "Price", "Stock");
            for (int i = 0; i < productCount; i++)
                Console.WriteLine("{0,-5} {1,-15} {2,-10} {3,-10}", i, products[i].Name, products[i].Price, products[i].Stock);
            Console.WriteLine("Press any key..."); Console.ReadKey();
        }
        static void SaveUsers()
        {
            StreamWriter sw = new StreamWriter("users.txt");
            for (int i = 0; i < userCount; i++) sw.WriteLine($"{users[i].Username},{users[i].Password},{users[i].Role}");
            sw.Close();
        }
        static void LoadUsers()
        {
            if (File.Exists("users.txt"))
            {
                StreamReader sr = new StreamReader("users.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] d = line.Split(',');
                    users[userCount++] = new MUser(d[0], d[1], d[2]);
                }
                sr.Close();
            }
        }
        static void SaveProducts()
        {
            StreamWriter sw = new StreamWriter("products.txt");
            for (int i = 0; i < productCount; i++) sw.WriteLine($"{products[i].Name},{products[i].Price},{products[i].Stock}");
            sw.Close();
        }
        static void LoadProducts()
        {
            if (File.Exists("products.txt"))
            {
                StreamReader sr = new StreamReader("products.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] d = line.Split(',');
                    products[productCount++] = new Product(d[0], Convert.ToDouble(d[1]), Convert.ToInt32(d[2]));
                }
                sr.Close();
            }
        }
    }
}
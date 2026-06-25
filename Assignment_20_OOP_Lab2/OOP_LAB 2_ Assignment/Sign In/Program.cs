using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign_In_task
{
    class MUser
    {
        public string Username;
        public string Password;
        public string Role;
        public MUser(string user, string pass, string role)
        {
            Username = user;
            Password = pass;
            Role = role;
        }
    }
    class Program
    {
        static MUser[] users = new MUser[100];
        static int userCount = 0;
        static string path = "users.txt";

        static void Main(string[] args)
        {
            Console.Clear();
            LoadDataFromFile();

            string choice = "";
            while (choice != "3")
            {
                Console.WriteLine("\n--- WELCOME TO LOGIN SYSTEM ---");
                Console.WriteLine("1. SignUp (Register)");
                Console.WriteLine("2. SignIn (Login)");
                Console.WriteLine("3. Exit Program");
                Console.Write("Select Option: ");
                choice = Console.ReadLine();

                if (choice == "1") { SignUp(); }
                else if (choice == "2") { SignIn(); }
                else if (choice == "3") { Console.WriteLine("Exiting... Good Bye!"); }
                else { Console.WriteLine("Invalid Option! Please try again."); }
            }
        }

        static void SignUp()
        {
            Console.Write("Enter New Username: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter Role (Admin/User): ");
            string role = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(role))
            {
                Console.WriteLine("Error: All fields are required!");
                return;
            }
            users[userCount] = new MUser(name, pass, role);
            userCount++;
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + pass + "," + role);
            file.Close();

            Console.WriteLine("Registration Successful!");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        static void SignIn()
        {
            Console.Write("Enter Username: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("Error: Please enter both username and password!");
                return;
            }
            bool found = false;
            for (int i = 0; i < userCount; i++)
            {
                if (users[i].Username == name && users[i].Password == pass)
                {
                    Console.WriteLine("\nLOGIN SUCCESSFUL!");
                    Console.WriteLine("Welcome, " + users[i].Username + " (Role: " + users[i].Role + ")");
                    found = true;
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Error: Invalid Username or Password!");
            }
        }
        static void LoadDataFromFile()
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    if (record.Contains(","))
                    {
                        string[] split = record.Split(',');
                        if (split.Length == 3)
                        {
                            users[userCount] = new MUser(split[0], split[1], split[2]);
                            userCount++;
                        }
                    }
                }
                file.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assesment_15_SignUp_Classes.BL;
namespace Assesment_15_SignUp_Classes
{
    public class AuthUI
    {
        public static int GetValidOption(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static string GetValidUsername(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && !input.Contains(" "))
                {
                    return input;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static string GetValidRole(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input.ToLower() == "admin" || input.ToLower() == "user")
                {
                    return char.ToUpper(input[0]) + input.Substring(1).ToLower();
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static string GetMaskedPassword(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;

            while (true)
            {
                string password = "";
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (key.Key != ConsoleKey.Backspace && key.KeyChar != '\0')
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                }
                if (!string.IsNullOrWhiteSpace(password))
                {
                    return password;
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
            int option = 0;
            while (option != 3)
            {
                Console.Clear();
                Console.WriteLine("=== SIGN-IN / SIGN-UP APPLICATION ===");
                Console.WriteLine("1. Sign Up (Register)");
                Console.WriteLine("2. Sign In (Login)");
                Console.WriteLine("3. Exit");
                option = AuthUI.GetValidOption("Enter Option (1-3): ", 1, 3);

                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine("--- SIGN UP ---");
                    string name = AuthUI.GetValidUsername("Enter Username (No spaces): ");
                    string pass = AuthUI.GetMaskedPassword("Enter Password: ");
                    string role = AuthUI.GetValidRole("Enter Role (Admin / User): ");

                    MUser newUser = new MUser(name, pass, role);
                    bool isSuccess = MUser.addUserIntoList(newUser);
                    if (isSuccess)
                        Console.WriteLine("\nSuccess: User Registered Successfully!");
                    else
                        Console.WriteLine("\nError: Username already exists! Try a different name.");

                    Console.ReadLine();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("--- SIGN IN ---");
                    string name = AuthUI.GetValidUsername("Enter Username: ");
                    string pass = AuthUI.GetMaskedPassword("Enter Password: ");

                    MUser tempUser = new MUser(name, pass, "NA");
                    MUser loggedInUser = MUser.isValid(tempUser);

                    if (loggedInUser != null)
                    {
                        Console.WriteLine($"\nWelcome back, {loggedInUser.userName}!");
                        if (loggedInUser.isAdmin())
                        {
                            Console.WriteLine("-> This is Admin Menu.");
                        }
                        else
                        {
                            Console.WriteLine("-> This is User Menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: Invalid Username or Password!");
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
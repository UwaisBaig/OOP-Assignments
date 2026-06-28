using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreSystem
{
  
    class Book
    {
        public string Title;
        public List<string> Authors;
        public string Publisher;
        public string ISBN;
        public double Price;
        public int Stock;
        public int YearOfPublication;

        public Book(string title, List<string> authors, string publisher, string isbn, double price, int stock, int year)
        {
            Title = title;
            Authors = authors;
            Publisher = publisher;
            ISBN = isbn;
            Price = price;
            Stock = stock;
            YearOfPublication = year;
        }

        public void DisplayBook()
        {
            Console.WriteLine($"Title: {Title}, ISBN: {ISBN}, Price: ${Price}, Stock: {Stock}");
        }

        public void UpdateStock(int amount)
        {
            Stock += amount;
            if (Stock < 0) Stock = 0;
        }
    }

    // --- CHALLENGE 02: Member Class ---
    class Member
    {
        public string Name;
        public int MemberID;
        public List<Book> BooksBought;
        public int NumBooksBought;
        public double AmountSpent;

        public Member(string name, int memberId)
        {
            Name = name;
            MemberID = memberId;
            BooksBought = new List<Book>();
            NumBooksBought = 0;
            AmountSpent = 0;
        }

        public void DisplayMember()
        {
            string type = MemberID == 0 ? "Non-Member" : "Member";
            Console.WriteLine($"Name: {Name}, ID: {MemberID} ({type}), Books Bought: {NumBooksBought}, Spent: ${AmountSpent}");
        }
    }

    // --- CHALLENGE 03: Driver Program ---
    class Program
    {
        static List<Book> inventory = new List<Book>();
        static List<Member> members = new List<Member>();
        static double totalSales = 0;
        static double totalMembershipFees = 0;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Bookstore Management System ---");
                Console.WriteLine("a. Add a Book");
                Console.WriteLine("b. Search for a Book by Title");
                Console.WriteLine("c. Search for a Book by ISBN");
                Console.WriteLine("d. Update Stock of a Book");
                Console.WriteLine("e. Add a Member");
                Console.WriteLine("f. Search for a Member");
                Console.WriteLine("g. Update Member Information");
                Console.WriteLine("h. Purchase a Book");
                Console.WriteLine("i. Display Total Sales and Stats");
                Console.WriteLine("j. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "a": AddBook(); break;
                    case "b": SearchBookByTitle(); break;
                    case "c": SearchBookByISBN(); break;
                    case "d": UpdateStock(); break;
                    case "e": AddMember(); break;
                    case "f": SearchMember(); break;
                    case "g": UpdateMember(); break;
                    case "h": PurchaseBook(); break;
                    case "i": DisplayStats(); break;
                    case "j": running = false; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Authors (comma separated): ");
            List<string> authors = Console.ReadLine().Split(',').ToList();
            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter Year: ");
            int year = int.Parse(Console.ReadLine());

            inventory.Add(new Book(title, authors, publisher, isbn, price, stock, year));
            Console.WriteLine("Book added successfully.");
        }

        static void SearchBookByTitle()
        {
            Console.Write("Enter Title to search: ");
            string title = Console.ReadLine();
            var book = inventory.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null) book.DisplayBook();
            else Console.WriteLine("Book not found.");
        }

        static void SearchBookByISBN()
        {
            Console.Write("Enter ISBN to search: ");
            string isbn = Console.ReadLine();
            var book = inventory.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null) book.DisplayBook();
            else Console.WriteLine("Book not found.");
        }

        static void UpdateStock()
        {
            Console.Write("Enter ISBN to update stock: ");
            string isbn = Console.ReadLine();
            var book = inventory.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                Console.Write("Enter amount to add/subtract (e.g., 5 or -2): ");
                int amt = int.Parse(Console.ReadLine());
                book.UpdateStock(amt);
                Console.WriteLine("Stock updated.");
            }
            else Console.WriteLine("Book not found.");
        }

        static void AddMember()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Member ID (0 for non-member): ");
            int id = int.Parse(Console.ReadLine());

            members.Add(new Member(name, id));
            if (id != 0)
            {
                totalMembershipFees += 10; // $10 yearly fee
                Console.WriteLine("Member added. $10 fee collected.");
            }
            else
            {
                Console.WriteLine("Non-member profile created.");
            }
        }

        static void SearchMember()
        {
            Console.Write("Enter Member ID (or Name for non-members): ");
            string input = Console.ReadLine();

            Member mem = null;
            if (int.TryParse(input, out int id) && id != 0)
                mem = members.FirstOrDefault(m => m.MemberID == id);
            else
                mem = members.FirstOrDefault(m => m.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (mem != null) mem.DisplayMember();
            else Console.WriteLine("Member not found.");
        }

        static void UpdateMember()
        {
            Console.Write("Enter current Member ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var mem = members.FirstOrDefault(m => m.MemberID == id);

            if (mem != null)
            {
                Console.Write("Enter new Name: ");
                mem.Name = Console.ReadLine();
                Console.WriteLine("Member updated.");
            }
            else Console.WriteLine("Member not found.");
        }

        static void PurchaseBook()
        {
            Console.Write("Enter Member ID (0 for non-member): ");
            int id = int.Parse(Console.ReadLine());
            var mem = members.FirstOrDefault(m => m.MemberID == id);

            if (mem == null)
            {
                Console.WriteLine("Profile not found. Please add member/non-member first.");
                return;
            }

            Console.Write("Enter ISBN of the book to purchase: ");
            string isbn = Console.ReadLine();
            var book = inventory.FirstOrDefault(b => b.ISBN == isbn);

            if (book != null && book.Stock > 0)
            {
                double finalPrice = book.Price;

                if (mem.MemberID != 0)
                {
                    // 5% discount for members
                    finalPrice -= (finalPrice * 0.05);

                    // 11th book discount logic
                    if ((mem.NumBooksBought + 1) % 11 == 0)
                    {
                        double discount = mem.AmountSpent / 10;
                        finalPrice -= discount;
                        if (finalPrice < 0) finalPrice = 0;
                        mem.AmountSpent = 0; // Reset after 11th book
                        Console.WriteLine($"11th Book Bonus Applied! Discount: ${discount}");
                    }
                }

                book.UpdateStock(-1);
                mem.BooksBought.Add(book);
                mem.NumBooksBought++;
                mem.AmountSpent += finalPrice;
                totalSales += finalPrice;

                Console.WriteLine($"Purchase successful. You paid: ${finalPrice}");
            }
            else
            {
                Console.WriteLine("Book not found or out of stock.");
            }
        }

        static void DisplayStats()
        {
            int memberCount = members.Count(m => m.MemberID != 0);
            Console.WriteLine($"Total Sales: ${totalSales}");
            Console.WriteLine($"Total Members: {memberCount}");
            Console.WriteLine($"Total Membership Fees Collected: ${totalMembershipFees}");
        }
    }
}
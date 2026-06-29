using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    class Program
    {
        static void Main()
        {
            int option;
            do
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (option == 1)
                {
                    BookBL b = BookUI.takeInput();
                    BookDL.addBook(b);
                    Console.WriteLine("Book added successfully!\n");
                }
                else if (option == 2)
                {
                    Console.WriteLine("\n--- Library Books ---");
                    foreach (BookBL b in BookDL.books)
                    {
                        BookUI.showBook(b);
                    }
                }
                else if (option == 3)
                {
                    Console.Write("Enter Title to search: ");
                    string title = Console.ReadLine();
                    BookBL b = BookDL.searchBook(title);

                    Console.WriteLine();
                    if (b != null)
                    {
                        BookUI.showBook(b);
                    }
                    else
                    {
                        Console.WriteLine("Book Not Found\n");
                    }
                }
            } while (option != 4);
        }
    }
}
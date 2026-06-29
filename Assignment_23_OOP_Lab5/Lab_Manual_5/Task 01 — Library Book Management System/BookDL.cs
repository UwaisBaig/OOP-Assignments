using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrarySystem
{
    public class BookDL
    {
        public static List<BookBL> books = new List<BookBL>();

        public static void addBook(BookBL b)
        {
            books.Add(b);
        }

        public static BookBL searchBook(string title)
        {
            foreach (BookBL b in books)
            {
                if (b.title == title)
                {
                    return b;
                }
            }
            return null;
        }
    }
}
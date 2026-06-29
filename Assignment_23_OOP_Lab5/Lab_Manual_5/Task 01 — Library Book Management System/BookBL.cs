using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrarySystem
{
    public class BookBL
    {
        public string title;
        public string author;
        public double price;

        public BookBL(string title, string author, double price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Author
{
    public string name;
    public string email;
    public char gender;

    public Author() { }

    public Author(string name, string email, char gender)
    {
        this.name = name;
        this.email = email;
        this.gender = gender;
    }
}

class Book
{
    public string name;
    public Author author;
    public float price;
    public int quantity;

    public Book() { }

    public Book(string name, Author author, float price, int quantity)
    {
        this.name = name;
        this.author = author;
        this.price = price;
        this.quantity = quantity;
    }
}
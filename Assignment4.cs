using System;

namespace Assignment4
{
    class BOOKS
    {
        public string title;
        public string author;
        public decimal price;
        public int quantity;


        public void DislayDetails()
        {
            Console.WriteLine("Title= " + title + "| Author= " + author + "| Price= $" + price + "| Quantity= " + quantity);
        }

        public void SellBooks(int amount)
        {
            if (quantity >= amount)
            {
                quantity = quantity - amount;
                Console.WriteLine("Sold " + amount + " copies of '" + title + "'.");

            }
            else
            {
                Console.WriteLine("Error: Cannot sell " + amount + " copies of '" + title + "'. Only " + quantity + " left in stock!");
            }

        }
        public void AddStock(int amount)
        {
            quantity = quantity + amount;
            Console.WriteLine("Added " + amount + " copies to '" + title + "'.");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BOOKS book1 = new BOOKS();
            book1.title = "Art of War";
            book1.author = "sun tzu";
            book1.price = 500.80m;
            book1.quantity = 9;

            BOOKS book2 = new BOOKS();
            book2.title = "Atomic Habbits";
            book2.author = "James Clear";
            book2.price = 450.75m;
            book2.quantity = 8;

            Console.WriteLine("----Displaying Details of the Books----");
            book1.DislayDetails();
            book2.DislayDetails();

            Console.WriteLine("----Stimulating Details----");
            book1.SellBooks(5);
            book2.SellBooks(3);

            book1.AddStock(10);
            book2.AddStock(20);

            Console.WriteLine("----Displaying Updated Details----");
            book1.DislayDetails();
            book2.DislayDetails();


            Console.ReadKey();

        }
    }

}
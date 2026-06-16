using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Product
{
    private string name;
    private string category;
    private int price;
    private int stock;
    private int minimumStock;

    public bool setStock(int stock)
    {
        if (stock <= -1 || stock > 100)
        {
            return false;
        }
        this.stock = stock;
        return true;
    }

    public int getStock()
    {
        return stock;
    }

    public string getProductName()
    {
        return name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product p = new Product();

        Console.WriteLine("Enter Stock");
        int stock = int.Parse(Console.ReadLine());

        bool stockFlag = p.setStock(stock);

        if (!stockFlag)
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("Stock updated successfully: " + p.getStock());
        }

        Console.Read();
    }
}
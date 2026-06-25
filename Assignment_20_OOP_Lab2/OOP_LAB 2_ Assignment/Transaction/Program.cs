using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Transaction
{
    public int TransactionId;
    public string ProductName;
    public double Amount;
    public string DateTime;

    public Transaction()
    {
    }
    public Transaction(Transaction t)
    {
        TransactionId = t.TransactionId;
        ProductName = t.ProductName;
        Amount = t.Amount;
        DateTime = t.DateTime;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Transaction t1 = new Transaction();
        t1.TransactionId = 101;
        t1.ProductName = "Laptop";
        t1.Amount = 85000;
        t1.DateTime = "12-03-2026";

        Transaction t2 = new Transaction(t1);

        Console.WriteLine(t1.TransactionId);
        Console.WriteLine(t1.ProductName);
        Console.WriteLine(t1.Amount);
        Console.WriteLine(t1.DateTime);
        Console.WriteLine(t2.ProductName);
        Console.WriteLine(t2.ProductName);
        Console.WriteLine(t2.Amount);
        Console.WriteLine(t2.DateTime);
    }
}
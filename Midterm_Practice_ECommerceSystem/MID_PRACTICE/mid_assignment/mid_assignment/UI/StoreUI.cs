using System;
using StoreSystem.BL;

namespace StoreSystem.UI
{
    public class StoreUI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayTotalSales(float totalSales)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"TOTAL STORE SALES: ${totalSales}");
            Console.WriteLine("=====================================");
        }
    }
}
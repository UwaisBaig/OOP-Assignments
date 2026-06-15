using System.Collections.Generic;
using StoreSystem.BL;

namespace StoreSystem.DL
{
    public class StoreDL
    {
        public static List<Customer> CustomersList = new List<Customer>();
        public static List<Product> ProductsList = new List<Product>();
        public static List<Order> MasterOrderList = new List<Order>();

        public static void AddCustomer(Customer c)
        {
            CustomersList.Add(c);
        }

        public static void AddProduct(Product p)
        {
            ProductsList.Add(p);
        }

        public static void RecordOrder(Order o)
        {
            MasterOrderList.Add(o);
        }
    }
}
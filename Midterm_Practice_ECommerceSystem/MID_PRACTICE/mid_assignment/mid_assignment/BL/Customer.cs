using System;
using System.Collections.Generic;

namespace StoreSystem.BL
{
    public class Customer
    {
        private int customerId;
        private string userName;
        private string password;
        private ShoppingCart cart;
        private List<Order> orderHistory;

        public int CustomerId { get { return customerId; } }
        public string UserName { get { return userName; } }
        public ShoppingCart Cart { get { return cart; } }
        public List<Order> OrderHistory { get { return orderHistory; } }

        public Customer(int customerId, string userName, string password, ShoppingCart cart)
        {
            this.customerId = customerId;
            this.userName = userName;
            this.password = password;
            this.cart = cart;
            this.orderHistory = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orderHistory.Add(order);
        }

        public List<Order> DisplayOrderHistory()
        {
            return orderHistory;
        }
    }
}
using System;
using System.Collections.Generic;

namespace StoreSystem.BL
{
    public class ShoppingCart
    {
        private int cartId;
        private string color;
        private List<Product> items;

        public int CartId { get { return cartId; } set { cartId = value; } }
        public string Color { get { return color; } set { color = value; } }

        public ShoppingCart(int cartId, string color)
        {
            this.cartId = cartId;
            this.color = color;
            this.items = new List<Product>();
        }

        public void AddItem(Product p)
        {
            items.Add(p);
        }

        public void RemoveItem(int pId)
        {
            items.RemoveAll(p => p.ProductId == pId);
        }

        public List<Product> GetItems()
        {
            return items;
        }

        public float GetTotalPrice()
        {
            float total = 0;
            foreach (Product p in items)
            {
                total += p.Price;
            }
            return total;
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }
}
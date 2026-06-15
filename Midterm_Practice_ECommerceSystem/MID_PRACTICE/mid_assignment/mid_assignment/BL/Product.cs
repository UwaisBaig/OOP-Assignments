using System;

namespace StoreSystem.BL
{
    public class Product
    {
        private int productId;
        private string name;
        private float price;

        public int ProductId { get { return productId; } set { productId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public float Price { get { return price; } set { price = value; } }

        public Product(int productId, string name, float price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }
    }
}
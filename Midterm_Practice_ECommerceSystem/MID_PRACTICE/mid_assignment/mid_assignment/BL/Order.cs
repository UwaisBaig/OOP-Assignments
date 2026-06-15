using System;

namespace StoreSystem.BL
{
    public class Order
    {
        private int orderId;
        private float totalAmount;

        public int OrderId { get { return orderId; } set { orderId = value; } }
        public float TotalAmount { get { return totalAmount; } set { totalAmount = value; } }

        public Order(int orderId, float totalAmount)
        {
            this.orderId = orderId;
            this.totalAmount = totalAmount;
        }
    }
}
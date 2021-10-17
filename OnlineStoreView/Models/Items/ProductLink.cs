using System;

namespace OnlineStoreView.Models
{
    public class ProductLink : Link
    {
        public string Description { get; }
        public decimal Price { get; }
        public int Quantity { get; private set; }

        public ProductLink(Type linkedMenuType, string name, string description, decimal price, int quantity) : base(name, linkedMenuType)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
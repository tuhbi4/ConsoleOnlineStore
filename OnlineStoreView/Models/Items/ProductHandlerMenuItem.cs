using System;
using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models
{
    public class ProductHandlerMenuItem : HandlerMenuItem
    {
        public Product Product { get; protected set; }

        public ProductHandlerMenuItem(Product product) : this(product, typeof(ProductQuantityInputMenuViewModel))
        {
        }

        public ProductHandlerMenuItem(Product product, Type handler) : base(product.Name, handler)
        {
            Product = product;
        }

        public void UpdateQuantity(int quantity)
        {
            Product.Quantity = quantity;
        }
    }
}
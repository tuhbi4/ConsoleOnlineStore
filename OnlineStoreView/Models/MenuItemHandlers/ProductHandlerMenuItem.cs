using System;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Views;

namespace OnlineStoreView.Models
{
    public class ProductHandlerMenuItem : MenuItemHandler
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
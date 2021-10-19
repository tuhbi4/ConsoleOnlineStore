using System;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Views;

namespace OnlineStoreView.Models
{
    public class ProductMenuItemHandler : MenuItemHandler
    {
        public Product Product { get; protected set; }

        public ProductMenuItemHandler(Product product) : this(product, typeof(ProductQuantityInputView)) { }

        public ProductMenuItemHandler(Product product, Type handler) : base(product.Name, handler)
        {
            Product = product;
        }

        public void UpdateQuantity(int quantity)
        {
            Product.Quantity = quantity;
        }
    }
}
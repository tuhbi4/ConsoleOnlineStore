﻿using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Views;

namespace OnlineStoreView.Models
{
    public class ProductMenuItemHandler : MenuItemHandler
    {
        public Product Product { get; protected set; }

        public ProductMenuItemHandler(Product product) : base(product.Name, typeof(ProductQuantityInputView))
        {
            Product = product;
        }
    }
}
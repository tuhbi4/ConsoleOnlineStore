using System;
using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models.MenuItemHandlers
{
    public class ProductItemHandler : MenuItemHandler
    {
        public Product Product { get; private set; }

        public ProductItemHandler(Product product, Type nextView) : base(product.Name, nextView)
        {
            Product = product;
        }
    }
}
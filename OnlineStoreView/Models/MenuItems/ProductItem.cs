using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models.MenuItems
{
    public class ProductItem : MenuItem
    {
        public Product Product { get; }

        public ProductItem(Product Product) : base(Product.Name)
        {
            this.Product = Product;
        }
    }
}
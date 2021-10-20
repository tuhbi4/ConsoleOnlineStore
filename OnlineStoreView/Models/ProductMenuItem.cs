using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models
{
    public class ProductMenuItem : MenuItem
    {
        public Product Product { get; protected set; }

        public ProductMenuItem(Product product) : base(product.Name)
        {
            Product = product;
        }
    }
}
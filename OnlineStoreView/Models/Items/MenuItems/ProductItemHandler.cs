using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.ZView
{
    public class ProductItemHandler : MenuItemHandler
    {
        public Product Product { get; private set; }

        public ProductItemHandler(Product product, ViewType nextView) : base(product.Name, nextView)
        {
            Product = product;
        }

    }
}
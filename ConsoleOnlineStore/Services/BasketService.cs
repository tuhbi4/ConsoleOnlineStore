using System.Collections.Generic;

namespace ConsoleOnlineStore.Services
{
    public class BasketService : IBasketService
    {
        public List<Product> Basket { get; }

        public void AddProduct(Product product, int quantity)
        {
            Product existingProduct = Basket.Find(x => x.Id.Contains(product.Id));
            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;
            }
            else
            {
                Basket.Add(product);
                product.Quantity = quantity;
            }
        }

        public void ClearBasket()
        {
            Basket.Clear();
        }
    }
}
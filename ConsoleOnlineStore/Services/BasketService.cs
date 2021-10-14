using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces.ServiceInterfaces;
using ConsoleOnlineStore.Models.RepositoryModels;

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

        public void ClearBasket(object obj)
        {
            Basket.Clear();
        }
    }
}
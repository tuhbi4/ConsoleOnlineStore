using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class BasketService : IBasketService
    {
        public List<Product> Basket { get; private set; }

        public int TryAddProduct(Product product, int quantity)
        {
            Product existingProduct = Basket.Find(x => x.Id.Contains(product.Id));

            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;

                return 0;
            }
            else
            {
                Basket.Add(product);
                product.Quantity = quantity;

                return 1;
            }
        }

        public List<Product> GetBasket()
        {
            return Basket;
        }

        public void InitBasket()
        {
            Basket = new();
        }

        public void ClearBasket()
        {
            Basket.Clear();
        }
    }
}
using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IBasketService
    {
        public int TryAddProduct(Product product, int quantity);

        public List<Product> GetBasket();

        public void InitBasket();

        public void ClearBasket();
    }
}
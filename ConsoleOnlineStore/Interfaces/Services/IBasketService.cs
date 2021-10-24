using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IBasketService
    {
        public int TryAddProductToBasket(Basket basket, Product product, int quantity);
    }
}
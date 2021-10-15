using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IBasketService
    {
        public void AddProduct(Product product, int quantity);

        public void ClearBasket();
    }
}
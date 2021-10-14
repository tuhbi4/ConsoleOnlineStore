using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IBasketService
    {
        public void AddProduct(Product product, int quantity);

        public void ClearBasket(object obj);
    }
}
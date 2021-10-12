using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IBasketService
    {
        public void AddProduct(Product product);

        public void ClearBasket();

        public void SaveOrder();
    }
}
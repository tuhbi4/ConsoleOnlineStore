using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.View
{
    public interface IBasketFactory
    {
        public Basket Create(string accountLogin);
    }
}
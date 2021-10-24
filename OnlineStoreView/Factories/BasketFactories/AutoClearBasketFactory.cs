using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models.Baskets;
using OnlineStoreView.View;

namespace OnlineStoreView.Factories.BasketFactories
{
    public class AutoClearBasketFactory : IBasketFactory
    {
        private readonly int timerTimeOut;

        public AutoClearBasketFactory(int timerTimeOut)
        {
            this.timerTimeOut = timerTimeOut;
        }

        public Basket Create(string accountLogin)
        {
            return new AutoClearBasket(accountLogin, timerTimeOut);
        }
    }
}
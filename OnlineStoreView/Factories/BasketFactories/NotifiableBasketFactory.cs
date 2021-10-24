using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models.Baskets;
using OnlineStoreView.View;

namespace OnlineStoreView.Factories.BasketFactories
{
    public class NotifiableBasketFactory : IBasketFactory
    {
        private readonly ViewNotifier notifier;
        private readonly int timerTimeOut;

        public NotifiableBasketFactory(ViewNotifier notifier, int timerTimeOut)
        {
            this.notifier = notifier;
            this.timerTimeOut = timerTimeOut;
        }

        public Basket Create(string accountLogin)
        {
            return new NotifableBasket(notifier, accountLogin, timerTimeOut);
        }
    }
}
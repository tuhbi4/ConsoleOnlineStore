using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.View;

namespace OnlineStoreView.Interfaces
{
    public class ViewBuffer : IViewBuffer
    {
        private readonly IBasketFactory basketFactory;

        public ViewBuffer(IBasketFactory basketFactory)
        {
            this.basketFactory = basketFactory;
        }

        public string CurrentUser { get; private set; }

        public Product CurrentProduct { get; private set; }

        public Basket CurrentBasket { get; private set; }

        public Order CurrentOrder { get; private set; }

        public void SetCurrentUser(string accountLogin)
        {
            CurrentUser = accountLogin;
            CurrentBasket = basketFactory.Create(accountLogin);
        }

        public void ResetCurrentUser()
        {
            CurrentUser = null;
            CurrentBasket?.ClearBasket();
            CurrentBasket = null;
        }

        public void SetCurrentProduct(Product product)
        {
            CurrentProduct = product;
        }

        public void SetCurrentOrder(Order order)
        {
            CurrentOrder = order;
        }
    }
}
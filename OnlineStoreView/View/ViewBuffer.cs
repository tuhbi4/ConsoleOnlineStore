using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.View
{
    public class ViewBuffer : IViewBuffer
    {
        public string CurrentUser { get; private set; }

        public Product CurrentProduct { get; private set; }

        public Basket CurrentBasket { get; private set; }

        public Order CurrentOrder { get; private set; }

        public void SetCurrentUser(string accountLogin)
        {
            CurrentUser = accountLogin;
            CurrentBasket = new Basket(accountLogin);
        }

        public void ResetCurrentUser()
        {
            CurrentUser = null;
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
using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Interfaces
{
    public interface IViewBuffer
    {
        public string CurrentUser { get; }

        public Product CurrentProduct { get; }

        public Basket CurrentBasket { get; }

        public Order CurrentOrder { get; }

        public void SetCurrentUser(string accountLogin);

        public void ResetCurrentUser();

        public void SetCurrentProduct(Product product);

        public void SetCurrentOrder(Order order);
    }
}
using ConsoleOnlineStore;
using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class ClearBasketConfirmationView : ConfirmationView
    {
        private const string header = "Clear basket";

        public ClearBasketConfirmationView() : base(header)
        {
            Yes = new MenuItemHandler("Yes", typeof(BasketView));
            No = new MenuItemHandler("No", typeof(BasketView));
        }

        protected override void OnFinish()
        {
            StoreService.ClearBasket();
        }
    }
}
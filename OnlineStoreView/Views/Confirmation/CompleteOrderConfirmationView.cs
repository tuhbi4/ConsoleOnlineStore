using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class CompleteOrderConfirmationView : ConfirmationView
    {
        private const string header = "Complete order";

        public CompleteOrderConfirmationView() : base(header)
        {
            Yes = new MenuItemHandler("Yes", typeof(BasketView));
            No = new MenuItemHandler("No", typeof(BasketView));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
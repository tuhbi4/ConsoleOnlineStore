using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class CompleteOrderConfirmationMenuViewModel : ConfirmationView
    {
        private static readonly string header = "Complete order";

        public CompleteOrderConfirmationMenuViewModel() : base(header)
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
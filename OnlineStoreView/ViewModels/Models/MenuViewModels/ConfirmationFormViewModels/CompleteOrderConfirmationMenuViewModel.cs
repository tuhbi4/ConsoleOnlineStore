using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class CompleteOrderConfirmationMenuViewModel : ConfirmationMenuViewModel
    {
        private static readonly string header = "Complete order";

        public CompleteOrderConfirmationMenuViewModel() : base(header)
        {
            Yes = new HandlerMenuItem("Yes", typeof(BasketRepositorySelectionMenuViewModel));
            No = new HandlerMenuItem("No", typeof(BasketRepositorySelectionMenuViewModel));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
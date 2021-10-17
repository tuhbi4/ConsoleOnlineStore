using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class CompleteOrder : ConfirmationForm
    {
        private static readonly string header = "Complete order";

        public CompleteOrder() : base(header)
        {
            Yes = new Link("Yes", typeof(BasketService));
            No = new Link("No", typeof(BasketService));
        }
    }
}
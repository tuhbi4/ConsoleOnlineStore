using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class MainSelectionMenuViewModel : SelectionMenuViewModel
    {
        private static readonly string header = "Glad to see you here!";

        public MainSelectionMenuViewModel() : base(header)
        {
            Back = new HandlerMenuItem("Back", typeof(StartSelectionMenuViewModel));
            MenuItems = new()
            {
                new HandlerMenuItem("View catalog", typeof(CatalogRepositorySelectionMenuViewModel)),
                new HandlerMenuItem("View basket", typeof(BasketRepositorySelectionMenuViewModel)),
                new HandlerMenuItem("View purchase history", typeof(OrderHistoryRepositorySelectionMenuViewModel)),
                new HandlerMenuItem("Log out", typeof(LogoutConfirmationMenuViewModel)),
            };
        }

        public void UpdateHeader(string userName)
        {
            Header = $"Glad to see you here, {userName}!";
        }
    }
}
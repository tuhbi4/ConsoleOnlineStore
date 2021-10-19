using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class MainMenuView : MenuView
    {
        private static readonly string header = "Glad to see you here!";

        public MainMenuView() : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(StartMenuView));
            MenuItems = new()
            {
                new MenuItemHandler("View catalog", typeof(CatalogView)),
                new MenuItemHandler("View basket", typeof(BasketView)),
                new MenuItemHandler("View purchase history", typeof(OrderHistoryView)),
                new MenuItemHandler("Log out", typeof(LogoutConfirmationView)),
            };
        }

        public void UpdateHeader(string userName)
        {
            Header = $"Glad to see you here, {userName}!";
        }
    }
}
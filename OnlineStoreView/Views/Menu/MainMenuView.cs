using ConsoleOnlineStore;
using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class MainMenuView : MenuView
    {
        public MainMenuView() : base($"Glad to see you here, {StoreService.CurrentUser}!")
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
    }
}
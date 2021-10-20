using ConsoleOnlineStore;
using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class MainMenuView : MenuView
    {
        public MainMenuView() : base(string.Empty)
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

        public override void Render(StoreService storeService)
        {
            Header = $"Glad to see you here, {storeService.CurrentUser}!";
            base.Render(storeService);
        }
    }
}
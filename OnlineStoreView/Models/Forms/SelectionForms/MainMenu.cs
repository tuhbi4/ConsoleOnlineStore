using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class MainMenu : SelectionForm
    {
        private static readonly string header = "Glad to see you here!";

        public MainMenu() : base(header)
        {
            MenuItems = new()
            {
                new Link("View catalog", typeof(CatalogService)),
                new Link("View basket", typeof(BasketService)),
                new Link("View purchase history", typeof(OrderHistoryService)),
                new Link("Log out", typeof(LogoutMenu)),
                new Link("Back", typeof(StartMenu)),
            };
        }

        public void UpdateHeader(string userName)
        {
            Header = $"Glad to see you here, {userName}!";
        }
    }
}
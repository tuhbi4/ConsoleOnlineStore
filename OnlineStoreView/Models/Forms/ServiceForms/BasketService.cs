using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class BasketService : ServiceForm
    {
        private static readonly string header = "Basket";

        public BasketService() : base(header)
        {
            MenuItems = new()
            {
                new Link("<Button>", typeof(BasketService)),
                new Link("<Button>", typeof(BasketService)),
            };
            Back = new Link("Back", typeof(MainMenu));
        }
    }
}
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class OrderHistoryService : ServiceForm
    {
        private static readonly string header = "Purchase history";

        public OrderHistoryService() : base(header)
        {
            MenuItems = new()
            {
                new Link("<Button>", typeof(OrderHistoryService)),
                new Link("<Button>", typeof(OrderHistoryService)),
            };
            Back = new Link("Back", typeof(MainMenu));
        }
    }
}
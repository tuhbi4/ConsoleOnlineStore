using System.Collections.Generic;
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
            };
            Back = new Link("Back", typeof(MainMenu));
        }

        public OrderHistoryService(List<Order> orderList) : base(header)
        {
            MenuItems = new();
            foreach (Order order in orderList)
            {
                MenuItems.Add(new Order(order.Caption, typeof(CompleteOrder), order.AccountID, order.ProductList, order.PurchaseDate));
            }
            Back = new Link("Back", typeof(MainMenu));
        }
    }
}
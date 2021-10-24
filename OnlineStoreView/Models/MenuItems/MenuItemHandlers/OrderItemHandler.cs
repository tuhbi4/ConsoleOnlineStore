using System;
using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models.MenuItems.MenuItemHandlers
{
    public class OrderItemHandler : MenuItemHandler
    {
        public Order Order { get; private set; }

        public OrderItemHandler(Order order, Type nextView) : base(order.PurchaseDate.ToLocalTime().ToString(), nextView)
        {
            Order = order;
        }
    }
}
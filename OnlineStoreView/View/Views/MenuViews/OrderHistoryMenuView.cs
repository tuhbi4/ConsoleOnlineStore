using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class OrderHistoryMenuView : MenuView<OrderItemHandler>
    {
        private readonly IOrderService orderService;
        private readonly IViewBuffer buffer;

        public OrderHistoryMenuView(IOrderService orderService, IViewBuffer buffer)
        {
            this.orderService = orderService;
            this.buffer = buffer;
            Header = new("Purchase history");
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new();
            MaxItemIndex = 0;
            WrongIndexMessage = new("Enter correct number");
        }

        protected override void BeforePrintMenu()
        {
            List<Order> orderList = orderService.GetOrdersHistory(buffer.CurrentUser);
            MaxItemIndex = orderList.Count;
            MenuItems = new();

            foreach (Order order in orderList)
            {
                MenuItems.Add(new OrderItemHandler(order, typeof(OrderDetailsMenuView)));
            }

            MaxItemIndex = MenuItems.Count;
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            return MenuItems[Input - 1].NextViewType;
        }

        protected override void OnFinish()
        {
            if (Input != 0)
            {
                buffer.SetCurrentOrder(MenuItems[Input - 1].Order);
            }
        }

        protected override void PrintMenuItems()
        {
            var i = 0;

            if (MenuItems.Count != 0)
            {
                foreach (OrderItemHandler item in MenuItems)
                {
                    LineRenderer.Warning($"\n{++i}. {item.Caption}");
                }
            }
            else
            {
                LineRenderer.Warning($"\nYou haven't bought anything from us yet. Maybe it's time for shopping?");
            }
        }
    }
}
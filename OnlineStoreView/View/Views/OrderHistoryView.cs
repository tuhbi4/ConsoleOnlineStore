using System.Collections.Generic;
using ConsoleOnlineStore;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.ZView
{
    public sealed class OrderHistoryView : RepositoryView
    {
        private const string header = "Purchase history";

        public new List<MenuItemHandler> MenuItems { get; set; }

        public OrderHistoryView() : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new() { };
            OnInit();
        }

        public void OnInit()
        {
            List<Order> ordertList = storeService.GetOrderHistory();

            if (ordertList != null)
            {
                foreach (Order order in ordertList)
                {
                    MenuItems.Add(new MenuItemHandler(order.PurchaseDate.ToLocalTime().ToString(), typeof(OrderDetailsMenuView)));
                }
            }
        }

        public override void Render(StoreService storeService)
        {
            this.storeService = storeService;

            do
            {
                PrintMenu();
                GetUserInput();
            }
            while (!IsValidUserInput());

            if (Input == 0)
            {
                Handler = Back.Handler;
            }
            else if (Input > 0 && Input < MenuItems.Count + 1)
            {
                Handler = MenuItems[Input - 1].Handler;
                List<Order> ordertList = storeService.GetOrderHistory();
                storeService.SetCurrentOrder(ordertList[Input - 1]);
            }
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            int i = 0;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            if (MenuItems.Count != 0)
            {
                foreach (Header item in MenuItems)
                {
                    LineRenderer.Warning($"{++i}. {item.Caption}");
                }
            }
            else
            {
                LineRenderer.Warning("\nYou haven't bought anything from us yet. Maybe it's time for shopping?\n");
            }

            LineRenderer.Secondary("\nEnter the number of your choice:\n");

            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error(ErrorMessage + "\n");
                ErrorMessage = string.Empty;
            }
        }

        public override bool IsValidUserInput()
        {
            if (Input < 0 || Input > MenuItems.Count)
            {
                if (ErrorMessage == string.Empty)
                {
                    ErrorMessage = "We understand that it is very difficult to make a choice, but you must try again! :).";
                }

                return false;
            }

            return true;
        }
    }
}
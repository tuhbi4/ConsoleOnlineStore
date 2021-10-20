using System.Collections.Generic;
using ConsoleOnlineStore;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class MenuView : View
    {
        public List<MenuItem> MenuItems { get; protected set; }

        protected MenuView(string header) : base(header) { }

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
            else if (Input > 0 && Input <= MenuItems.Count)
            {
                MenuItemHandler item = MenuItems[Input - 1] as MenuItemHandler;
                Handler = item.Handler;
            }
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            var i = 0;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            foreach (MenuItem item in MenuItems)
            {
                LineRenderer.Primary($"{++i}. {item.Caption}");
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
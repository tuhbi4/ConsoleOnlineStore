using System.Collections.Generic;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class MenuView : View
    {
        public MenuItemHandler Back { get; protected set; }
        public List<MenuItem> MenuItems { get; protected set; }

        protected MenuView(string header) : base(header)
        {
        }

        public override void Render()
        {
            do
            {
                PrintMenu();
                GetUserInput();
            }
            while (!IsValidUserInput());

            if (Input == 1)
            {
                Handler = Back.Handler;
            }
            else if (Input > 1 && Input <= MenuItems.Count + 1)
            {
                MenuItemHandler item = MenuItems[Input - 2] as MenuItemHandler;
                Handler = item.Handler;
            }
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            var i = 1;
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
            if (Input < 1 || Input > MenuItems.Count + 1)
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
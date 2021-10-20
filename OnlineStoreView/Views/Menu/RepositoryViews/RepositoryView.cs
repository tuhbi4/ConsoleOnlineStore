using System.Collections.Generic;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class RepositoryView : MenuView
    {
        public new List<MenuItemHandler> MenuItems { get; protected set; }

        protected RepositoryView(string header) : base(header) { }

        public override void Render()
        {
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
            else if (Input > 0 && Input < MenuItems.Count)
            {
                Handler = MenuItems[Input - 1].Handler;
            }
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            var i = 0;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            foreach (MenuItemHandler item in MenuItems)
            {
                LineRenderer.Primary($"{++i}. {item.Caption}");
            }

            LineRenderer.Secondary("\nEnter the number of your choice:\n");
        }
    }
}
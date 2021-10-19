using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public sealed class CatalogView : RepositoryView
    {
        private static readonly string header = "Catalog";

        public new List<ProductMenuItemHandler> MenuItems { get; set; }

        public CatalogView() : base(header)
        {
            MenuItems = new() { };
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
        }

        public CatalogView(List<Product> productList) : base(header)
        {
            MenuItems = new();

            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductMenuItemHandler(product));
            }

            Back = new MenuItemHandler("Back", typeof(MainMenuView));
        }

        protected override void OnInit()
        {
            // TODO: Call to product catalog repository
            // MenuItems = new() { //...// };
        }

        protected override void OnFinish()
        {
            // TODO: Buy or clear
        }

        public override void Render()
        {
            OnInit();

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
                Handler = MenuItems[Input - 2].Handler;
            }

            OnFinish();
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            int i = 1;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            if (MenuItems.Count != 0)
            {
                foreach (ProductMenuItemHandler item in MenuItems)
                {
                    LineRenderer.Information($"\n{++i}. {item.Caption}");
                    LineRenderer.Secondary($"   << {item.Product.Description} >>");
                    LineRenderer.Primary($"   Price : {item.Product.Price}");
                    LineRenderer.Warning($"   In stock : {item.Product.Quantity}\n");
                }
            }
            else
            {
                LineRenderer.Warning("\nSorry, but we are not selling anything right now =(\n");
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
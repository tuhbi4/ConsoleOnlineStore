using System.Collections.Generic;
using ConsoleOnlineStore;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.ZView
{
    public sealed class CatalogView : RepositoryView
    {
        private const string header = "Catalog";

        public new List<ProductMenuItemHandler> MenuItems { get; set; }

        public CatalogView() : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new() { };
            OnInit();
        }

        public void OnInit()
        {
            List<Product> productList = storeService.GetCatalog();

            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductMenuItemHandler(product));
            }
        }

        public void OnFinish(Product product)
        {
            storeService.SetCurrentProduct(product);
        }

        public override void Render(StoreService storeService)
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
            else if (Input > 0 && Input <= MenuItems.Count)
            {
                Handler = MenuItems[Input - 1].Handler;
                OnFinish(MenuItems[Input - 1].Product);
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
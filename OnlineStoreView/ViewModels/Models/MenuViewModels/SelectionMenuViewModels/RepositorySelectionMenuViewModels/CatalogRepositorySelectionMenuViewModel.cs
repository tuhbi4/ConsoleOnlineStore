using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class CatalogRepositorySelectionMenuViewModel : RepositorySelectionMenuViewModel
    {
        private static readonly string header = "Catalog";

        public new List<ProductHandlerMenuItem> MenuItems { get; set; }

        public CatalogRepositorySelectionMenuViewModel() : base(header)
        {
            MenuItems = new()
            {
                new ProductHandlerMenuItem(new Product("0001", "Apple", "Sweet Apple", 1.99m, 2)),
                new ProductHandlerMenuItem(new Product("0002", "Orange", "Juicy Orange", 2.99m, 1)),
                new ProductHandlerMenuItem(new Product("0003", "Banana", "Mmm Banana", 3.99m, 1)),
            };
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
        }

        public CatalogRepositorySelectionMenuViewModel(List<Product> productList) : base(header)
        {
            MenuItems = new();
            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductHandlerMenuItem(product));
            }
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
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
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            int i = 1;
            PrintLineService.Secondary($"\n{i}. {Back.Caption}\n");
            if (MenuItems.Count != 0)
            {
                foreach (ProductHandlerMenuItem item in MenuItems)
                {
                    PrintLineService.Information($"\n{++i}. {item.Caption}");
                    PrintLineService.Secondary($"   << {item.Product.Description} >>");
                    PrintLineService.Primary($"   Price : {item.Product.Price}");
                    PrintLineService.Warning($"   In stock : {item.Product.Quantity}\n");
                }
            }
            else
            {
                PrintLineService.Warning("\nSorry, but we are not selling anything right now =(\n");
            }
            PrintLineService.Secondary("\nEnter the number of your choice:\n");
            if (ErrorMessage != string.Empty)
            {
                PrintLineService.Error(ErrorMessage + "\n");
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
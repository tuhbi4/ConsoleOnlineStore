using System.Collections.Generic;
using ConsoleOnlineStore;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public sealed class BasketView : RepositoryView
    {
        private const string header = "Basket";

        public new List<ProductMenuItemHandler> MenuItems { get; set; }

        public MenuItemHandler Buy { get; }

        public MenuItemHandler Clear { get; }

        public BasketView() : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new() { };
            Buy = new MenuItemHandler("Buy", typeof(CompleteOrderConfirmationView));
            Clear = new MenuItemHandler("Clear", typeof(ClearBasketConfirmationView));
            OnInit();
        }

        public void OnInit()
        {
            List<Product> basket = StoreService.GetBasket();

            foreach (Product product in basket)
            {
                MenuItems.Add(new ProductMenuItemHandler(product));
            }
        }

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
            else if (Input > 0 && Input <= MenuItems.Count)
            {
                Handler = MenuItems[Input - 1].Handler;
            }
            else if (Input == MenuItems.Count + 1)
            {
                Handler = Buy.Handler;
            }
            else if (Input == MenuItems.Count + 2)
            {
                Handler = Clear.Handler;
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
                    LineRenderer.Information($"{++i}. {item.Caption}");
                    LineRenderer.Secondary($"   << {item.Product.Description} >>");
                    LineRenderer.Primary($"   Price : {item.Product.Price}");
                    LineRenderer.Warning($"   Quantity : {item.Product.Quantity}\n");
                }

                LineRenderer.Success($"\n{++i}. {Buy.Caption}");
                LineRenderer.Error($"{++i}. {Clear.Caption}\n");
            }
            else
            {
                LineRenderer.Warning("\nYour basket is empty!\n");
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
            if (Input < 0 || Input > MenuItems.Count + 2)
            {
                if (ErrorMessage == string.Empty)
                {
                    ErrorMessage = "Enter correct number.";
                }

                return false;
            }

            return true;
        }
    }
}
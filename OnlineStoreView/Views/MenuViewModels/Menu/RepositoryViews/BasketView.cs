using System.Collections.Generic;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public sealed class BasketView : RepositoryView
    {
        private static readonly string header = "Basket";

        public new List<ProductHandlerMenuItem> MenuItems { get; set; }
        public MenuItemHandler Buy { get; }
        public MenuItemHandler Clear { get; }

        public BasketView() : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new()
            {
            };
            Buy = new MenuItemHandler("Buy", typeof(CompleteOrderConfirmationMenuViewModel));
            Clear = new MenuItemHandler("Clear", typeof(MainMenuView));
        }

        public BasketView(BasketHandlerMenuItem basket) : base(header)
        {
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = basket.ProductList;
            Buy = new MenuItemHandler("Buy", typeof(CompleteOrderConfirmationMenuViewModel));
            Clear = new MenuItemHandler("Clear", typeof(MainMenuView));
        }

        protected override void OnInit()
        {
            // TODO: Call to basket repository
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
            else if (Input == MenuItems.Count + 2)
            {
                Handler = Buy.Handler;
            }
            else if (Input == MenuItems.Count + 3)
            {
                Handler = Clear.Handler;
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
                foreach (ProductHandlerMenuItem item in MenuItems)
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
            if (Input < 1 || Input > MenuItems.Count + 3)
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
using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class BasketRepositorySelectionMenuViewModel : RepositorySelectionMenuViewModel
    {
        private static readonly string header = "Basket";

        public new List<ProductHandlerMenuItem> MenuItems { get; set; }
        public HandlerMenuItem Buy { get; }
        public HandlerMenuItem Clear { get; }

        public BasketRepositorySelectionMenuViewModel() : base(header)
        {
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
            MenuItems = new()
            {
                new ProductHandlerMenuItem(new Product("0001", "Apple", "Sweet Apple", 1.99m, 2)),
            };
            Buy = new HandlerMenuItem("Buy", typeof(CompleteOrderConfirmationMenuViewModel));
            Clear = new HandlerMenuItem("Clear", typeof(MainSelectionMenuViewModel));
        }

        public BasketRepositorySelectionMenuViewModel(BasketHandlerMenuItem basket) : base(header)
        {
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
            MenuItems = basket.ProductList;
            Buy = new HandlerMenuItem("Buy", typeof(CompleteOrderConfirmationMenuViewModel));
            Clear = new HandlerMenuItem("Clear", typeof(MainSelectionMenuViewModel));
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
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            int i = 1;
            PrintLineService.Secondary($"\n{i}. {Back.Caption}\n");
            if (MenuItems.Count != 0)
            {
                foreach (ProductHandlerMenuItem item in MenuItems)
                {
                    PrintLineService.Information($"{++i}. {item.Caption}");
                    PrintLineService.Secondary($"   << {item.Product.Description} >>");
                    PrintLineService.Primary($"   Price : {item.Product.Price}");
                    PrintLineService.Warning($"   Quantity : {item.Product.Quantity}\n");
                }
                PrintLineService.Success($"\n{++i}. {Buy.Caption}");
                PrintLineService.Error($"{++i}. {Clear.Caption}\n");
            }
            else
            {
                PrintLineService.Warning("\nYour basket is empty!\n");
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
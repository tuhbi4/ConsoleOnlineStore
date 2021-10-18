using System.Collections.Generic;
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class OrderHistoryRepositorySelectionMenuViewModel : RepositorySelectionMenuViewModel
    {
        private static readonly string header = "Purchase history";
        public new List<OrderBasketHandlerMenuItem> MenuItems { get; set; }

        public OrderHistoryRepositorySelectionMenuViewModel() : base(header)
        {
            MenuItems = new()
            {
            };
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
        }

        public OrderHistoryRepositorySelectionMenuViewModel(List<OrderBasketHandlerMenuItem> orderList) : base(header)
        {
            MenuItems = new();
            foreach (OrderBasketHandlerMenuItem order in orderList)
            {
                MenuItems.Add(new OrderBasketHandlerMenuItem(order.Caption, typeof(CompleteOrderConfirmationMenuViewModel), order.AccountId, order.ProductList, order.PurchaseDate));
            }
            Back = new HandlerMenuItem("Back", typeof(MainSelectionMenuViewModel));
        }

        protected override void OnInit()
        {
            // TODO: Call to product order repository
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
                foreach (OrderBasketHandlerMenuItem order in MenuItems)
                {
                    PrintLineService.Warning($"{++i}. {order.PurchaseDate}");
                    int j = 0;
                    foreach (ProductHandlerMenuItem product in order.ProductList)
                    {
                        PrintLineService.Primary($"   {++j}. Product: {product.Caption}");
                        PrintLineService.Primary($"      Price : {product.Product.Price}");
                        PrintLineService.Primary($"      Quantity : {product.Product.Quantity}\n");
                    }
                }
            }
            else
            {
                PrintLineService.Warning("\nYou haven't bought anything from us yet. Maybe it's time for shopping?\n");
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
                    ErrorMessage = "Enter correct number.";
                }

                return false;
            }

            return true;
        }
    }
}
using System.Collections.Generic;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public sealed class OrderHistoryView : RepositoryView
    {
        private static readonly string header = "Purchase history";

        public new List<OrderMenuItemHandler> MenuItems { get; set; }

        public OrderHistoryView() : base(header)
        {
            MenuItems = new() { };
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
        }

        public OrderHistoryView(List<OrderMenuItemHandler> orderList) : base(header)
        {
            MenuItems = new();
            foreach (OrderMenuItemHandler order in orderList)
            {
                MenuItems.Add(new OrderMenuItemHandler(order.Caption, typeof(CompleteOrderConfirmationView), order.AccountId, order.ProductList, order.PurchaseDate));
            }
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
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
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            int i = 1;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            if (MenuItems.Count != 0)
            {
                foreach (OrderMenuItemHandler order in MenuItems)
                {
                    LineRenderer.Warning($"{++i}. {order.PurchaseDate}");
                    int j = 0;

                    foreach (ProductMenuItemHandler product in order.ProductList)
                    {
                        LineRenderer.Primary($"   {++j}. Product: {product.Caption}");
                        LineRenderer.Primary($"      Price : {product.Product.Price}");
                        LineRenderer.Primary($"      Quantity : {product.Product.Quantity}\n");
                    }
                }
            }
            else
            {
                LineRenderer.Warning("\nYou haven't bought anything from us yet. Maybe it's time for shopping?\n");
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
                    ErrorMessage = "Enter correct number.";
                }

                return false;
            }

            return true;
        }
    }
}
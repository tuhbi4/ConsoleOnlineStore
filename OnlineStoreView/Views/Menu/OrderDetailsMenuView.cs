using System;
using ConsoleOnlineStore;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public sealed class OrderDetailsMenuView : MenuView
    {
        public OrderDetailsMenuView() : base($"Order details from {StoreService.CurrentOrder.PurchaseDate.ToLocalTime()}:")
        {
            Back = new MenuItemHandler("Back", typeof(OrderHistoryView));
        }

        public override void Render()
        {
            do
            {
                PrintMenu();
                GetUserInput();
            }
            while (!IsValidUserInput());

            Handler = Back.Handler;
        }

        public override void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            var i = 0;
            LineRenderer.Secondary($"\n{i}. {Back.Caption}\n");

            foreach (Product product in StoreService.CurrentOrder.ProductList)
            {
                LineRenderer.Secondary($"      {i++}");
                LineRenderer.Warning($"          Name : {product.Name}");
                LineRenderer.Primary($"   Description : {product.Description}");
                LineRenderer.Primary($"         Price : {product.Price}");
                LineRenderer.Primary($"      Quantity : {product.Quantity}\n");
            }

            LineRenderer.Secondary("\nEnter the number of your choice:\n");

            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error(ErrorMessage + "\n");
                ErrorMessage = string.Empty;
            }
        }

        public override void GetUserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                ErrorMessage = "This is not a number.";
                Input = -1;
            }
            else
            {
                Input = input;
            }
        }

        public override bool IsValidUserInput()
        {
            if (Input != 0)
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
using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.ConfirmationViews
{
    public sealed class CompleteOrderConfirmationView : ConfirmationView
    {
        private readonly IOrderService orderService;
        private readonly IViewBuffer buffer;

        public CompleteOrderConfirmationView(IOrderService orderService, IViewBuffer buffer)
        {
            Header = new("Are you sure you want to complete order ? ");
            Back = new MenuItemHandler("No", typeof(BasketMenuView));
            Yes = new MenuItemHandler("Yes", typeof(BasketMenuView));
            MaxItemIndex = 1;
            WrongIndexMessage = new("Enter correct number");
            this.orderService = orderService;
            this.buffer = buffer;
        }

        protected override void OnSelectYes()
        {
            List<BasketItem> missingProducts = new();

            if (orderService.CompleteOrder(buffer.CurrentBasket, out missingProducts))
            {
                LineRenderer.Loading("We are checking your order...", "", "Your order has been successfully sent for processing!", ConsoleColor.Green, 3);
            }
            else
            {
                LineRenderer.Loading("We are checking your order...", "", "We are sorry, some products are not enough for your order.", ConsoleColor.Red, 3);
                LineRenderer.Loading("Try to reduce the quantity of the following products(you can check the actual stocks in the catalog)", "", "", ConsoleColor.Red, 3);

                foreach (BasketItem item in missingProducts)
                {
                    LineRenderer.Warning($" > {item.Product.Name}");
                }

                LineRenderer.Loading("", "", "", ConsoleColor.Red, 3);
                // TODO: throw a message about the change in the basket (use missingProducts list)
            }
        }
    }
}
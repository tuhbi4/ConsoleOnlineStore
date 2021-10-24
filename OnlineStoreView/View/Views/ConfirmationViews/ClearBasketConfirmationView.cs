using System;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.ConfirmationViews
{
    public sealed class ClearBasketConfirmationView : ConfirmationView
    {
        private readonly IViewBuffer buffer;

        public ClearBasketConfirmationView(IViewBuffer buffer)
        {
            Header = new("Are you sure you want to clear basket?");
            Back = new MenuItemHandler("No", typeof(BasketMenuView));
            Yes = new MenuItemHandler("Yes", typeof(BasketMenuView));
            MaxItemIndex = 1;
            WrongIndexMessage = new("Enter correct number");
            this.buffer = buffer;
        }

        protected override void OnSelectYes()
        {
            buffer.CurrentBasket.ClearBasket();
            LineRenderer.Loading("Clearing your basket...", "", "Done!", ConsoleColor.Green, 2);
        }
    }
}
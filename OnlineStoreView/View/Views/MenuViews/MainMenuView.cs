using System;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.ConfirmationViews;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class MainMenuView : MenuView<MenuItemHandler>
    {
        private readonly IViewBuffer buffer;

        public MainMenuView(IViewBuffer buffer)
        {
            Header = new(string.Empty);
            Back = new MenuItemHandler("Back", typeof(StartMenuView));
            MenuItems = new()
            {
                new MenuItemHandler("View catalog", typeof(CatalogMenuView)),
                new MenuItemHandler("View basket", typeof(BasketMenuView)),
                new MenuItemHandler("View purchase history", typeof(OrderHistoryMenuView)),
                new MenuItemHandler("Log out", typeof(LogoutConfirmationView)),
            };
            MaxItemIndex = 4;
            WrongIndexMessage = new("Enter correct number");
            this.buffer = buffer;
        }

        protected override void BeforePrintMenu()
        {
            Header = new($"Glad to see you here, {buffer.CurrentUser}!");
        }

        protected override void PrintMenuItems()
        {
            LineRenderer.Primary(string.Empty);
            var i = 0;

            foreach (MenuItemHandler item in MenuItems)
            {
                LineRenderer.Primary($"{++i}. {item.Caption}");
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            return MenuItems[Input - 1].NextViewType;
        }

        protected override void OnFinish() { }
    }
}
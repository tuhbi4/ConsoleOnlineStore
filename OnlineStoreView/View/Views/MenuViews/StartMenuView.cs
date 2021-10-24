using System;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.ConfirmationViews;
using OnlineStoreView.View.Views.InputViews;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class StartMenuView : MenuView<MenuItemHandler>
    {
        public StartMenuView()
        {
            Header = new("Welcome to the Best Console Store in the whole universe!");
            Back = null;
            MenuItems = new()
            {
                new MenuItemHandler("Log in", typeof(AuthorizationInputView)),
                new MenuItemHandler("Create an account", typeof(RegistrationInputView)),
                new MenuItemHandler("Exit", typeof(ExitConfirmationView)),
            };
            MaxItemIndex = 3;
            WrongIndexMessage = new("Enter correct number");
        }

        protected override void BeforePrintMenu() { }

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
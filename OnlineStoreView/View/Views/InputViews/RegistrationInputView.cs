using System;
using ConsoleOnlineStore.Interfaces.Services;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItems;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.InputViews
{
    public sealed class RegistrationInputView : InputView
    {
        private readonly IAccountService accountService;
        private readonly IViewBuffer buffer;
        private bool isSuccess;

        public RegistrationInputView(IAccountService accountService, IViewBuffer buffer)
        {
            this.accountService = accountService;
            this.buffer = buffer;
            Header = new("Enter the details to create a new account");
            Back = new MenuItemHandler("Cancel", typeof(StartMenuView));
            MaxItemIndex = 0;
            WrongIndexMessage = new("Enter correct number");
            MenuItems = new()
            {
                new InputItem("Come up with a login"),
                new InputItem("Come up with a password"),
            };
        }

        protected override void BeforePrintMenu() { }

        protected override void OnFinish()
        {
            int opCode = accountService.TryRegister(MenuItems[0].Input, MenuItems[1].Input);

            if (opCode == 1)
            {
                OnSuccess();
            }
            else
            {
                OnError(opCode);
            }
        }

        private void OnSuccess()
        {
            isSuccess = true;
            buffer.SetCurrentUser(MenuItems[0].Input);
            LineRenderer.Loading("Connecting to database...", "*", "Account created successfully! Log in...", ConsoleColor.Green, 4);
        }

        private static void OnError(int opCode)
        {
            if (opCode == 0)
            {
                LineRenderer.Loading("Connecting to database...", "*", "An account with this username already exists. Try again...", ConsoleColor.Yellow, 4);
            }
            else
            {
                LineRenderer.Loading("Connecting to database...", "*", "Something went wrong. Try again...", ConsoleColor.Red, 4);
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            if (isSuccess)
            {
                return typeof(MainMenuView);
            }

            return typeof(RegistrationInputView);
        }
    }
}
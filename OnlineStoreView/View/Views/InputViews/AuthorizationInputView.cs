using System;
using ConsoleOnlineStore.Interfaces.Services;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Models.MenuItems;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.InputViews
{
    public sealed class AuthorizationInputView : InputView
    {
        private readonly IAccountService accountService;
        private readonly IViewBuffer buffer;
        private bool isSuccess;

        public AuthorizationInputView(IAccountService accountService, IViewBuffer buffer)
        {
            this.accountService = accountService;
            this.buffer = buffer;
            Header = new("Enter your account details for log in");
            Back = new MenuItemHandler("Cancel", typeof(StartMenuView));
            MaxItemIndex = 0;
            WrongIndexMessage = new("Enter correct number");
            MenuItems = new()
            {
                new InputItem("Enter login"),
                new InputItem("Enter password"),
            };
        }

        protected override void BeforePrintMenu() { }

        protected override void OnFinish()
        {
            if (Input != 0)
            {
                int opCode = accountService.TryLogin(MenuItems[0].Input, MenuItems[1].Input);

                if (opCode == 1)
                {
                    OnSuccess();
                }
                else
                {
                    OnError(opCode);
                }
            }
        }

        private void OnSuccess()
        {
            isSuccess = true;
            buffer.SetCurrentUser(MenuItems[0].Input);
            LineRenderer.Loading("Connecting to database...", "*", "Success!", ConsoleColor.Green, 3);
        }

        private static void OnError(int opCode)
        {
            if (opCode == 0)
            {
                LineRenderer.Loading("Connecting to database...", "*", "Invalid password!", ConsoleColor.Yellow, 3);
            }
            else
            {
                LineRenderer.Loading("Connecting to database...", "*", "No such account exists!", ConsoleColor.Red, 3);
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            if (isSuccess)
            {
                return typeof(MainMenuView);
            }

            return typeof(AuthorizationInputView);
        }
    }
}
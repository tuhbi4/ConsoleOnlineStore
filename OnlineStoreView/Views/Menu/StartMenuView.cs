using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class StartMenuView : MenuView
    {
        private static readonly string header = "Welcome to the Best Console Store in the whole universe!";

        public StartMenuView() : base(header)
        {
            Back = new MenuItemHandler("Exit", typeof(ExitConfirmationView));
            MenuItems = new()
            {
                new MenuItemHandler("Log in", typeof(AuthorizationInputView)),
                new MenuItemHandler("Create an account", typeof(RegistrationInputView)),
            };
        }
    }
}
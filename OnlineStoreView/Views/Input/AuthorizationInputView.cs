using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class AuthorizationInputView : InputView
    {
        private static readonly string header = "Enter your account details for log in";

        public AuthorizationInputView() : base(header)
        {
            Cancel = new MenuItemHandler("Cancel", typeof(StartMenuView));
            MenuItems = new()
            {
                new MenuItem("Enter login"),
                new MenuItem("Enter password"),
            };
            SuccessHandler = typeof(MainMenuView);
            ErrorHandler = typeof(StartMenuView);
        }

        protected override void OnFinish()
        {
            if (true) // TODO: implement call to account repository for log in
            {
                OnSuccess();
            }
            else
            {
                OnError();
            }
        }
    }
}
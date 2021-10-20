using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class AuthorizationInputView : InputView
    {
        private const string header = "Enter your account details for log in";

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
            int opCode = storeService.TryLogin(Inputs[0], Inputs[1]);
            if (opCode == 1)
            {
                OnSuccess();
            }
            else
            {
                ErrorMessage = "Error";
                OnError(opCode);
            }
        }
    }
}
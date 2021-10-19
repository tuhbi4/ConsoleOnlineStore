using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public class RegistrationInputMenuViewModel : InputView
    {
        private static readonly string header = "Enter the details to create a new account";

        public RegistrationInputMenuViewModel() : base(header)
        {
            Cancel = new MenuItemHandler("Cancel", typeof(StartMenuView));
            MenuItems = new()
            {
                new MenuItem("Come up with a login"),
                new MenuItem("Come up with a password"),
            };
            SuccessHandler = typeof(MainMenuView);
            ErrorHandler = typeof(StartMenuView);
        }

        protected override void OnFinish()
        {
            if (true) // TODO: implement call to account repository for register
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
using OnlineStoreView.Models;

namespace OnlineStoreView.ZView
{
    public class RegistrationInputView : InputView
    {
        private const string header = "Enter the details to create a new account";

        public RegistrationInputView() : base(header)
        {
            Cancel = new MenuItemHandler("Cancel", typeof(StartMenuView));
            MenuItems = new()
            {
                new Header("Come up with a login"),
                new Header("Come up with a password"),
            };
            SuccessHandler = typeof(MainMenuView);
            ErrorHandler = typeof(StartMenuView);
        }

        protected override void OnFinish()
        {
            int opCode = storeService.TryRegister(Inputs[0], Inputs[1]);
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
}
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public class RegistrationInputMenuViewModel : InputMenuViewModel
    {
        private static readonly string header = "Enter the details to create a new account";

        public RegistrationInputMenuViewModel() : base(header)
        {
            Cancel = new HandlerMenuItem("Cancel", typeof(StartSelectionMenuViewModel));
            MenuItems = new()
            {
                new MenuItem("Come up with a login"),
                new MenuItem("Come up with a password"),
            };
            SuccessHandler = typeof(MainSelectionMenuViewModel);
            ErrorHandler = typeof(StartSelectionMenuViewModel);
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
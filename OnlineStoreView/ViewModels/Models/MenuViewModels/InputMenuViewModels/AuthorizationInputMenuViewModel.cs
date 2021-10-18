using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class AuthorizationInputMenuViewModel : InputMenuViewModel
    {
        private static readonly string header = "Enter your account details for log in";

        public AuthorizationInputMenuViewModel() : base(header)
        {
            Cancel = new HandlerMenuItem("Cancel", typeof(StartSelectionMenuViewModel));
            MenuItems = new()
            {
                new MenuItem("Enter login"),
                new MenuItem("Enter password"),
            };
            SuccessHandler = typeof(MainSelectionMenuViewModel);
            ErrorHandler = typeof(StartSelectionMenuViewModel);
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
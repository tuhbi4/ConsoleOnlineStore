using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class StartSelectionMenuViewModel : SelectionMenuViewModel
    {
        private static readonly string header = "Welcome to the Best Console Store in the whole universe!";

        public StartSelectionMenuViewModel() : base(header)
        {
            Back = new HandlerMenuItem("Exit", typeof(ExitConfirmationMenuViewModel));
            MenuItems = new()
            {
                new HandlerMenuItem("Log in", typeof(AuthorizationInputMenuViewModel)),
                new HandlerMenuItem("Create an account", typeof(RegistrationInputMenuViewModel)),
            };
        }
    }
}
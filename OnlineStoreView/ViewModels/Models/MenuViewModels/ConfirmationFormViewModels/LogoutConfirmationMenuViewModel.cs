using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class LogoutConfirmationMenuViewModel : ConfirmationMenuViewModel
    {
        private static readonly string header = "Log out";

        public LogoutConfirmationMenuViewModel() : base(header)
        {
            Yes = new HandlerMenuItem("Yes", typeof(StartSelectionMenuViewModel));
            No = new HandlerMenuItem("No", typeof(MainSelectionMenuViewModel));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
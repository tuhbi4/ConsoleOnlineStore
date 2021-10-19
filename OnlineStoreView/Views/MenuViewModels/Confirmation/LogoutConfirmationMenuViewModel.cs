using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class LogoutConfirmationMenuViewModel : ConfirmationView
    {
        private static readonly string header = "Log out";

        public LogoutConfirmationMenuViewModel() : base(header)
        {
            Yes = new MenuItemHandler("Yes", typeof(StartMenuView));
            No = new MenuItemHandler("No", typeof(MainMenuView));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
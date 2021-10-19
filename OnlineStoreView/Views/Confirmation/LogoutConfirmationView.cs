using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class LogoutConfirmationView : ConfirmationView
    {
        private static readonly string header = "Log out";

        public LogoutConfirmationView() : base(header)
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
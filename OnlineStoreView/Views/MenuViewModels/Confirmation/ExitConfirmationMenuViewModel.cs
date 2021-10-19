using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class ExitConfirmationMenuViewModel : ConfirmationView
    {
        private static readonly string header = "Exit";

        public ExitConfirmationMenuViewModel() : base(header)
        {
            Yes = new MenuItemHandler("Yes", null);
            No = new MenuItemHandler("No", typeof(StartMenuView));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
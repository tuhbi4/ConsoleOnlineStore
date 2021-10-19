using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public sealed class ExitConfirmationView : ConfirmationView
    {
        private static readonly string header = "Exit";

        public ExitConfirmationView() : base(header)
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
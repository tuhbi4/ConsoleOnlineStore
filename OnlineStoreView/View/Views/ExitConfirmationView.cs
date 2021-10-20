using OnlineStoreView.Models;

namespace OnlineStoreView.ZView
{
    public sealed class ExitConfirmationView : ConfirmationView
    {
        private const string header = "Exit";

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
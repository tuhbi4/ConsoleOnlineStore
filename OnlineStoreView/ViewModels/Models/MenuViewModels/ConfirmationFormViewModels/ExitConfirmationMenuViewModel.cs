using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class ExitConfirmationMenuViewModel : ConfirmationMenuViewModel
    {
        private static readonly string header = "Exit";

        public ExitConfirmationMenuViewModel() : base(header)
        {
            Yes = new HandlerMenuItem("Yes", null);
            No = new HandlerMenuItem("No", typeof(StartSelectionMenuViewModel));
        }

        protected override void OnFinish()
        {
            // TODO: implement log out
        }
    }
}
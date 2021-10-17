using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class ExitMenu : ConfirmationForm
    {
        private static readonly string header = "Exit";

        public ExitMenu() : base(header)
        {
            Yes = new Link("Yes", null);
            No = new Link("No", typeof(StartMenu));
        }
    }
}
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class LogoutMenu : ConfirmationForm
    {
        private static readonly string header = "Log out";

        public LogoutMenu() : base(header)
        {
            Yes = new Link("Yes", typeof(StartMenu));
            No = new Link("No", typeof(MainMenu));
        }
    }
}
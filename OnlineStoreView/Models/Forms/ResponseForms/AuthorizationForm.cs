using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class AuthorizationForm : ResponseForm
    {
        private static readonly string header = "Enter your account details for log in";

        public AuthorizationForm() : base(header)
        {
            MenuItems = new()
            {
                new Span("Enter login"),
                new Span("Enter password"),
            };
            LinkedSuccessMenu = typeof(MainMenu);
            LinkedErrorMenu = typeof(StartMenu);
        }

        protected override void OnFinish()
        {
            CalledType = LinkedSuccessMenu; // TODO: implement call to account repository with success
        }
    }
}
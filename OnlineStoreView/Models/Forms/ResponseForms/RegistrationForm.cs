using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public class RegistrationForm : ResponseForm
    {
        private static readonly string header = "Enter the details to create a new account";

        public RegistrationForm() : base(header)
        {
            MenuItems = new()
            {
                new Span("Come up with a login"),
                new Span("Come up with a password"),
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
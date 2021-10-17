using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class StartMenu : SelectionForm
    {
        private static readonly string header = "Welcome to the Best Console Store in the whole universe!";

        public StartMenu() : base(header)
        {
            MenuItems = new()
            {
                new Link("Log in", typeof(AuthorizationForm)),
                new Link("Create an account", typeof(RegistrationForm)),
                new Link("Exit", typeof(ExitMenu)),
            };
        }
    }
}
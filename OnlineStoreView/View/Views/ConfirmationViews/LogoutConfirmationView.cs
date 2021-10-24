using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.ConfirmationViews
{
    public sealed class LogoutConfirmationView : ConfirmationView
    {
        private readonly IViewBuffer buffer;

        public LogoutConfirmationView(IViewBuffer buffer)
        {
            Header = new("Are you sure you want to log out?");
            Back = new MenuItemHandler("No", typeof(MainMenuView));
            Yes = new MenuItemHandler("Yes", typeof(StartMenuView));
            MaxItemIndex = 1;
            WrongIndexMessage = new("Enter correct number");
            this.buffer = buffer;
        }

        protected override void OnSelectYes()
        {
            buffer.ResetCurrentUser();
        }
    }
}
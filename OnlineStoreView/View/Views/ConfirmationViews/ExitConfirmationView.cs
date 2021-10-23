using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.ConfirmationViews
{
    public sealed class ExitConfirmationView : ConfirmationView
    {
        private readonly IViewBuffer buffer;

        public ExitConfirmationView(IViewBuffer buffer)
        {
            Header = new("Are you sure you want to exit?");
            Back = new MenuItemHandler("No", typeof(StartMenuView));
            Yes = new MenuItemHandler("Yes", null);
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
using System;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.View.Views.ConfirmationViews
{
    public abstract class ConfirmationView : View
    {
        public MenuItemHandler Yes { get; set; }

        protected override void PrintBody()
        {
            if (Yes != null) PrintYes();
        }

        protected override void BeforePrintMenu() { }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            return Yes.NextViewType;
        }

        protected override void OnFinish()
        {
            if (Input == 1)
            {
                OnSelectYes();
            }
        }

        protected abstract void OnSelectYes();

        protected override void PrintBack()
        {
            LineRenderer.Primary($"\n0. {Back.Caption}");
        }

        private void PrintYes()
        {
            LineRenderer.Primary($"1. {Yes.Caption}");
        }
    }
}
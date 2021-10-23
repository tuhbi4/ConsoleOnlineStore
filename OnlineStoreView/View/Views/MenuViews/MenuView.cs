using System.Collections.Generic;
using OnlineStoreView.Models.MenuItems;

namespace OnlineStoreView.View.Views.MenuViews
{
    public abstract class MenuView<T> : View where T : MenuItem
    {
        protected List<T> MenuItems { get; set; }

        protected override void PrintBody()
        {
            if (MenuItems != null)
            {
                PrintMenuItems();
            }
        }

        protected abstract void PrintMenuItems();
    }
}
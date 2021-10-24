using System;

namespace OnlineStoreView.Models.MenuItems.MenuItemHandlers
{
    public class MenuItemHandler : MenuItem
    {
        public Type NextViewType { get; }

        public MenuItemHandler(string caption, Type nextView) : base(caption)
        {
            NextViewType = nextView;
        }
    }
}
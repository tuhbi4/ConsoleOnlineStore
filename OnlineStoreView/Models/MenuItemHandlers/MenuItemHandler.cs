using System;
using OnlineStoreView.Models.MenuItems;

namespace OnlineStoreView.Models.MenuItemHandlers
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
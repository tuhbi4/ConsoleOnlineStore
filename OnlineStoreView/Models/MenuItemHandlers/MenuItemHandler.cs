using System;

namespace OnlineStoreView.Models
{
    public class MenuItemHandler : MenuItem
    {
        public Type Handler { get; protected set; }

        public MenuItemHandler(string caption, Type handler) : base(caption)
        {
            Handler = handler;
        }
    }
}
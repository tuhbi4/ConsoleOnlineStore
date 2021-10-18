using System;

namespace OnlineStoreView.Models
{
    public class HandlerMenuItem : MenuItem
    {
        public Type Handler { get; protected set; }

        public HandlerMenuItem(string caption, Type handler) : base(caption)
        {
            Handler = handler;
        }
    }
}
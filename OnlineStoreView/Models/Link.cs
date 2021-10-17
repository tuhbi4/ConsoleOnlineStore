using System;

namespace OnlineStoreView.Models
{
    public class Link : Span
    {
        public Type LinkedMenuType { get; }

        public Link(string caption, Type linkedMenuType) : base(caption)
        {
            LinkedMenuType = linkedMenuType;
        }
    }
}
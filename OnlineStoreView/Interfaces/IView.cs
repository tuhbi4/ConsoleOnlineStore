using System;

namespace OnlineStoreView.Interfaces
{
    public interface IView
    {
        public Type NextViewType { get; }

        public void Render();

        public void SetNotificationMessage(string message);
    }
}
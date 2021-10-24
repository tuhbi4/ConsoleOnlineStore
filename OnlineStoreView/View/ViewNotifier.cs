using OnlineStoreView.Interfaces;

namespace OnlineStoreView.View
{
    public class ViewNotifier : IViewNotifier
    {
        public delegate void OnNotifyHandler(string message);

        public event OnNotifyHandler OnNotify;

        public void Notify(string message)
        {
            OnNotify?.Invoke(message);
        }
    }
}
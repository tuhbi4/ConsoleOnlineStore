using OnlineStoreView.View;

namespace OnlineStoreView.Interfaces
{
    public interface IViewNotifier
    {
        event ViewNotifier.OnNotifyHandler OnNotify;

        void Notify(string message);
    }
}
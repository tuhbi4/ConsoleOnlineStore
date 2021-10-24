using System.Timers;
using OnlineStoreView.View;

namespace OnlineStoreView.Models.Baskets
{
    public delegate void NotifableBasketDelegate();

    public class NotifableBasket : AutoClearBasket
    {
        private readonly ViewNotifier notifier;

        public NotifableBasket(ViewNotifier notifier, string accountLogin, int timerTimeOut) : base(accountLogin, timerTimeOut)
        {
            this.notifier = notifier;
        }

        protected override void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            base.OnTimerElapsed(sender, args);
            notifier.Notify("Your basket was emptied due to timeout");
        }
    }
}
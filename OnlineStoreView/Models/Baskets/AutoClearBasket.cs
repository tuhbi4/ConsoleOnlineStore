using System.Timers;
using ConsoleOnlineStore.Models.Repositories;

namespace OnlineStoreView.Models.Baskets
{
    public class AutoClearBasket : Basket
    {
        public delegate void AutoClearBasketDelegate();

        public event AutoClearBasketDelegate OnAutoClear;

        protected Timer timer;

        public AutoClearBasket(string accountLogin, int timerTimeOut) : base(accountLogin)
        {
            timer = new Timer(timerTimeOut)
            {
                AutoReset = false
            };
        }

        public override void ClearBasket()
        {
            timer.Stop();
            timer.Elapsed -= OnTimerElapsed;
            base.ClearBasket();
        }

        public override void AddProduct(Product product, int quantity)
        {
            timer.Elapsed -= OnTimerElapsed;
            timer.Elapsed += OnTimerElapsed;
            timer.Stop();
            timer.Start();

            base.AddProduct(product, quantity);
        }

        protected virtual void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            ClearBasket();
            OnAutoClear?.Invoke();
        }
    }
}
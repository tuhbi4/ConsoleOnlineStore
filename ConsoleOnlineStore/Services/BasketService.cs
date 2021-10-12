using System.Collections.Generic;
using System.Threading;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class BasketService : IBasketService
    {
        public List<Product> Basket { get; }
        private readonly IRepository<Product> orderRepository;
        private readonly int timerTimeOut;

        public BasketService(IRepository<Product> orderRepository, int timerTimeOut)
        {
            this.orderRepository = orderRepository;
            this.timerTimeOut = timerTimeOut;
        }

        public void AddProduct(Product product)
        {
            Basket.Add(product);
            if (Basket.Count == 1)
            {
                int dueTime = timerTimeOut;
                TimerCallback callback = new(ClearBasket);
                using Timer timer = new(callback, null, dueTime, Timeout.Infinite);
            }
        }

        public void ClearBasket()
        {
            ClearBasket(null);
        }

        private void ClearBasket(object obj)
        {
            Basket.Clear();
        }

        public void CompleteOrder()
        {
            orderRepository.Create(Basket);
        }
    }
}
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
        private readonly IDeserializer<TimerModel> timerJsonDeserializer;

        public BasketService(IRepository<Product> orderRepository, IDeserializer<TimerModel> timerJsonDeserializer)
        {
            this.orderRepository = orderRepository;
            this.timerJsonDeserializer = timerJsonDeserializer;
        }

        public void AddProduct(Product product)
        {
            Basket.Add(product);
            if (Basket.Count == 1)
            {
                int dueTime = timerJsonDeserializer.GetData()[0].TimeOut;
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
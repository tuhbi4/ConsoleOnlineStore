using System.Collections.Generic;
using System.Threading;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class BasketService : IBasketService
    {
        public Basket Basket { get { return MakeBasket(); } }
        private readonly List<Product> productList = new();
        private readonly int accountID;
        private readonly IRepository<Order> orderRepository;
        private readonly int timerTimeOut;

        public BasketService(IRepository<Order> orderRepository, int timerTimeOut, int accountID)
        {
            this.orderRepository = orderRepository;
            this.timerTimeOut = timerTimeOut;
            this.accountID = accountID;
        }

        public void AddProduct(Product product)
        {
            productList.Add(product);
            if (productList.Count == 1)
            {
                RunClearTimer();
            }
        }

        private Basket MakeBasket()
        {
            Basket basket = new();
            foreach (Product product in productList)
            {
                foreach (BasketItem basketItem in basket.BasketList)
                {
                    if (basket.BasketList.Count != 0 && basketItem.Id == product.Id)
                    {
                        basketItem.Increment();
                    }
                    else
                    {
                        basket.BasketList.Add(new(product));
                    }
                }
            }
            return basket;
        }

        private void RunClearTimer()
        {
            int dueTime = timerTimeOut;
            TimerCallback callback = new(ClearBasket);
            using Timer timer = new(callback, null, dueTime, Timeout.Infinite);
        }

        public void ClearBasket()
        {
            ClearBasket(null);
        }

        private void ClearBasket(object obj)
        {
            productList.Clear();
        }

        public void SaveOrder()
        {
            orderRepository.Create(new Order(accountID, Basket));
        }
    }
}
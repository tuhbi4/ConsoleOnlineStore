using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public List<Order> GetOrdersHistory(string login)
        {
            List<Order> userOrders = new();
            List<Order> orders = orderRepository.Read();

            foreach (Order item in orders)
            {
                if (item.AccountLogin == login)
                {
                    userOrders.Add(item);
                }
            }

            return userOrders;
        }

        public bool CompleteOrder(Basket basket, out List<BasketItem> missingItems)
        {
            List<Product> catalog = productRepository.Read();
            missingItems = new();

            foreach (BasketItem item in basket.BasketItemList)
            {
                Product existingProduct = catalog.Find(x => x.Id.Contains(item.Product.Id));

                if (existingProduct.Quantity < item.AddedQuantity)
                {
                    missingItems.Add(item);
                }
            }

            if (missingItems.Count == 0)
            {
                CreateOrder(basket);
                basket.ClearBasket();

                return true;
            }

            return false;
        }

        private void CreateOrder(Basket basket)
        {
            var ordertList = orderRepository.Read();
            ordertList.Add(new Order(basket.AccountLogin, basket.GetProducts(), DateTime.UtcNow));
            orderRepository.Create(ordertList);
        }
    }
}
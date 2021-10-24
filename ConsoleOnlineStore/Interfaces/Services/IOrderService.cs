using System.Collections.Generic;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IOrderService
    {
        public List<Order> GetOrdersHistory(string login);

        public bool CompleteOrder(Basket basket, out List<BasketItem> missingItems);
    }
}
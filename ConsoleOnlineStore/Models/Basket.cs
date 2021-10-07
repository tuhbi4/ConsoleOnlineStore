using ConsoleOnlineStore.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace ConsoleOnlineStore.Models
{
    public class Basket : IBasket
    {
        public List<Product> ProductList { get; }
        private readonly Deserializer deserializer = new();
        private readonly Serializer serializer = new();
        private readonly string basketFilepath = ConfigurationManager.AppSettings.Get("basketDatabase");
        private readonly string timerFilepath = ConfigurationManager.AppSettings.Get("timerConfig");

        public Basket()
        {
            ProductList = new();
        }

        public void AddProductToBasket(Product product)
        {
            ProductList.Add(product);
            if (ProductList.Count == 1)
            {
                int dueTime = deserializer.GetTimerFromJson(timerFilepath);
                TimerCallback callback = new(ClearBasket);
                using Timer timer = new(callback, null, dueTime, Timeout.Infinite);
            }
        }

        public void ClearBasket()
        {
            ClearBasket(null);
        }

        public void ClearBasket(object obj)
        {
            ProductList.Clear();
        }

        public void CompletePurchase()
        {
            serializer.SaveProductListToJson(basketFilepath, ProductList);
        }
    }
}
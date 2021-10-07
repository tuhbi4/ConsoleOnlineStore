using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IBasket
    {
        public List<Product> ProductList { get; }

        public void AddProductToBasket(Product product);

        public void ClearBasket();

        public void CompletePurchase();
    }
}
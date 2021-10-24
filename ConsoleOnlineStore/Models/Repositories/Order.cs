using System;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Models.Repositories
{
    public class Order
    {
        public string AccountLogin { get; }

        public List<Product> ProductList { get; set; }

        public DateTime PurchaseDate { get; }

        public Order(string accountLogin, List<Product> productList, DateTime purchaseDate)
        {
            AccountLogin = accountLogin;
            ProductList = productList;
            PurchaseDate = purchaseDate;
        }
    }
}
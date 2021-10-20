using System;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Models.Repositories
{
    public class Order
    {
        public string AccountId { get; }

        public List<Product> ProductList { get; set; }

        public DateTime PurchaseDate { get; }

        public Order(string accountID, List<Product> productList, DateTime purchaseDate)
        {
            AccountId = accountID;
            ProductList = productList;
            PurchaseDate = purchaseDate;
        }
    }
}
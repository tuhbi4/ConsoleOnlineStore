using System;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Models.Repositories
{
    public class Order
    {
        public string AccountID { get; }
        public List<Product> ProductList { get; set; }
        public DateTime PurchaseDate { get; }

        public Order(string accountID, List<Product> productList)
        {
            AccountID = accountID;
            ProductList = productList;
            PurchaseDate = DateTime.UtcNow;
        }
    }
}
using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class Order : Basket
    {
        public string AccountID { get; }
        public DateTime PurchaseDate { get; }

        public Order(string caption, Type linkedMenuType, string accountID, List<ProductLink> productList, DateTime purchaseDate) : base(caption, linkedMenuType, productList)
        {
            AccountID = accountID;
            PurchaseDate = purchaseDate;
        }
    }
}
using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class OrderBasketHandlerMenuItem : BasketHandlerMenuItem
    {
        public string AccountId { get; }
        public DateTime PurchaseDate { get; }

        public OrderBasketHandlerMenuItem(string caption, Type linkedMenuType, string accountId, List<ProductHandlerMenuItem> productList, DateTime purchaseDate) : base(caption, linkedMenuType, productList)
        {
            AccountId = accountId;
            PurchaseDate = purchaseDate;
        }
    }
}
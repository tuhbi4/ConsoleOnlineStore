using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class OrderMenuItemHandler : BasketMenuItemHandler
    {
        public string AccountId { get; }

        public DateTime PurchaseDate { get; }

        public OrderMenuItemHandler(string caption, Type linkedMenuType, string accountId, List<ProductMenuItemHandler> productList, DateTime purchaseDate) : base(caption, linkedMenuType, productList)
        {
            AccountId = accountId;
            PurchaseDate = purchaseDate;
        }
    }
}
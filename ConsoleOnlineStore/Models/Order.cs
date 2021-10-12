using System;

namespace ConsoleOnlineStore.Models
{
    public class Order
    {
        public int AccountID { get; }
        public Basket Basket { get; }
        public DateTime PurchaseDate { get; }

        public Order(int accountID, Basket basket)
        {
            AccountID = accountID;
            Basket = basket;
            PurchaseDate = DateTime.UtcNow;
        }
    }
}
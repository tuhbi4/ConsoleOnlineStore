using System;

namespace ConsoleOnlineStore.Models
{
    public class Order
    {
        public int AccountID { get; set; }
        public Basket Basket { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
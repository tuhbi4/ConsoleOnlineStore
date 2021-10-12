namespace ConsoleOnlineStore.Models
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public string Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
namespace ConsoleOnlineStore.Models
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
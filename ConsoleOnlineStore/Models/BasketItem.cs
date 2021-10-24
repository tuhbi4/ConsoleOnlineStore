using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Models
{
    public class BasketItem
    {
        public int AddedQuantity { get; set; }

        public Product Product { get; set; }
    }
}
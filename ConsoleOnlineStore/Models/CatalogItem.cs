namespace ConsoleOnlineStore.Models
{
    public class CatalogItem
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int Quantity { get; private set; }

        public CatalogItem(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = 1;
        }

        public virtual void Increment()
        {
            Quantity++;
        }

        public virtual void Decrement()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
        }

        public virtual void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
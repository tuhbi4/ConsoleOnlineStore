namespace ConsoleOnlineStore.Models
{
    public class BasketItem : CatalogItem
    {
        public decimal Cost { get; private set; }

        public BasketItem(Product product) : base(product)
        {
            Cost = product.Price;
        }

        public override void Increment()
        {
            base.Increment();
            Cost += Price;
        }

        public override void Decrement()
        {
            base.Decrement();
            if (Cost > 0)
            {
                Cost -= Price;
            }
        }

        public override void AddQuantity(int quantity)
        {
            base.AddQuantity(quantity);
            Cost += Price * quantity;
        }
    }
}
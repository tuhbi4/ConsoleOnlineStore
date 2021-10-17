using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class BasketService : ServiceForm
    {
        private static readonly string header = "Basket";
        public Link Buy { get; }

        public BasketService() : base(header)
        {
            MenuItems = new()
            {
            };
            Buy = new Link("Buy", typeof(CompleteOrder));
            Back = new Link("Back", typeof(MainMenu));
        }

        public BasketService(Basket basket) : base(header)
        {
            MenuItems = new();
            foreach (ProductLink product in basket.ProductList)
            {
                MenuItems.Add(new ProductLink(typeof(ReguestQuantityForm), product.Caption, product.Description, product.Price, product.Quantity));
            }
            Back = new Link("Back", typeof(MainMenu));
        }

        public override void Render()
        {
            var message = string.Empty;
            var validatorMessage = string.Empty;
            int input;

            do
            {
                input = GetInput(ref message, validatorMessage);
            }
            while (!IsValidAnswer(input, out validatorMessage) || input < 1 || input > MenuItems.Count + 2);

            if (input == MenuItems.Count + 1)
            {
                CalledType = Buy.LinkedMenuType;
            }
            else if (input == MenuItems.Count + 2)
            {
                CalledType = Back.LinkedMenuType;
            }
            else
            {
                Link linkItem = MenuItems[input - 1];
                CalledType = linkItem.LinkedMenuType;
            }
        }

        protected override void PrintMenu()
        {
            PrintColorLineService.Header($" > {Header}\n");
            int i = 1;
            if (MenuItems.Count != 0)
            {
                for (i = 1; i <= MenuItems.Count; i++)
                {
                    ProductLink menuItem = MenuItems[i - 1] as ProductLink;
                    PrintColorLineService.Information($"{i}. {menuItem.Caption}");
                    PrintColorLineService.Secondary($"   << {menuItem.Description} >>");
                    PrintColorLineService.Primary($"   Price : {menuItem.Price}");
                    PrintColorLineService.Warning($"   In stock : {menuItem.Quantity}\n");
                }
            }
            else
            {
                PrintColorLineService.Warning("\nYour basket is empty!");
            }
            PrintColorLineService.Information($"\n{i}. {Buy.Caption}");
            PrintColorLineService.Information($"\n{i + 1}. {Back.Caption}");
        }
    }
}
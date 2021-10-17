using System.Collections.Generic;
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public sealed class CatalogService : ServiceForm
    {
        private static readonly string header = "Catalog";

        public CatalogService() : base(header)
        {
            MenuItems = new()
            {
                new ProductLink(typeof(ReguestQuantityForm), "Apple", "Sweet Apple", 1.99m, 2),
                new ProductLink(typeof(ReguestQuantityForm), "Orange", "Juicy Orange", 2.99m, 1),
                new ProductLink(typeof(ReguestQuantityForm), "Banana", "Mmm Banana", 3.99m, 1),
            };
            Back = new Link("Back", typeof(MainMenu));
        }

        public CatalogService(List<Product> productList) : base(header)
        {
            MenuItems = new();
            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductLink(typeof(ReguestQuantityForm), product.Name, product.Description, product.Price, product.Quantity));
            }
            Back = new Link("Back", typeof(MainMenu));
        }

        protected override void PrintMenu()
        {
            PrintColorLineService.Header($" > {Header}\n");
            int i;
            for (i = 1; i <= MenuItems.Count; i++)
            {
                ProductLink menuItem = MenuItems[i - 1] as ProductLink;
                PrintColorLineService.Information($"{i}. {menuItem.Caption}");
                PrintColorLineService.Secondary($"   << {menuItem.Description} >>");
                PrintColorLineService.Primary($"   Price : {menuItem.Price}");
                PrintColorLineService.Warning($"   In stock : {menuItem.Quantity}\n");
            }
            PrintColorLineService.Information($"\n{i}. {Back.Caption}");
        }
    }
}
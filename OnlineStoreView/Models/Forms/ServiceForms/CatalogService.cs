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
                new Link("<Button>", typeof(CatalogService)),
                new Link("<Button>", typeof(CatalogService)),
            };
            Back = new Link("Back", typeof(MainMenu));
        }
    }
}
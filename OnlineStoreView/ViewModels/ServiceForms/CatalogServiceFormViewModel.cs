using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class CatalogServiceFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Catalog",
            "<Button>",
            "<Button>",
            "Back",
        };
    }
}
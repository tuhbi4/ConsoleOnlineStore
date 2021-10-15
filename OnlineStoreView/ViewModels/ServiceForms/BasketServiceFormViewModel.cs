using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class BasketServiceFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Basket",
            "<Button>",
            "<Button>",
            "Back",
        };
    }
}
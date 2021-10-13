using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class OrderHistoryServiceFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Purchase history",
            "<Button>",
            "<Button>",
            "Back",
        };
    }
}
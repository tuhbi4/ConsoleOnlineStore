using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class MainMenuSelectionFormsViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "View catalog",
            "View basket",
            "View purchase history",
            "Log out",
            "Back",
        };
    }
}
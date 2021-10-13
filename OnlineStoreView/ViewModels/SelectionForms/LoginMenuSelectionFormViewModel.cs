using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class LoginMenuSelectionFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Log in",
            "Create an account",
            "Exit",
        };
    }
}
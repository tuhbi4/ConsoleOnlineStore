using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class AuthorizationFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Enter login",
            "Enter password",
        };
    }
}
using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class LogoutMenuViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Log out",
        };
    }
}
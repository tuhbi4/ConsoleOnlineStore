using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class ExitMenuViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Exit",
        };
    }
}
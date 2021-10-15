using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.ViewModels
{
    public class RegistrationFormViewModel : IMenu
    {
        public List<string> Menu { get; } = new List<string>
        {
            "Come up with a login",
            "Come up with a password",
        };
    }
}
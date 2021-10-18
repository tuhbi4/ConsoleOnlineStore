using System;
using OnlineStoreView.Models;
using OnlineStoreView.Services;

namespace OnlineStoreView.ViewModels
{
    public class ViewModel
    {
        private MenuViewModel nextMenu;

        public ViewModel()
        {
            nextMenu = new StartSelectionMenuViewModel();
        }

        public void Init()
        {
            do
            {
                nextMenu.Render();
                if (nextMenu.Handler != null)
                {
                    nextMenu = Activator.CreateInstance(nextMenu.Handler) as MenuViewModel;
                }
                else
                {
                    PrintLineService.Success("\n Our store closes. Goodbye!");
                    break;
                }
            }
            while (true);
        }
    }
}
using System;
using OnlineStoreView.Models;
using OnlineStoreView.Services;

namespace OnlineStoreView.ViewModels
{
    public class ViewModel
    {
        private Menu nextMenu;

        public ViewModel()
        {
            nextMenu = new StartMenu();
        }

        public void Init()
        {
            do
            {
                nextMenu.Render();
                if (nextMenu.CalledType != null)
                {
                    nextMenu = Activator.CreateInstance(nextMenu.CalledType) as Menu;
                }
                else
                {
                    PrintColorLineService.Success("\n Our store closes. Goodbye!");
                    break;
                }
            }
            while (true);
        }
    }
}
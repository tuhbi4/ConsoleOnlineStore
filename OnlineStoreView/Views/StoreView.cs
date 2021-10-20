using System;
using ConsoleOnlineStore;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public class StoreView
    {
        private readonly StoreService storeService;
        private View nextMenu;

        public StoreView(StoreService storeService)
        {
            this.storeService = storeService;
            nextMenu = new StartMenuView();
        }

        public void Init()
        {
            do
            {
                nextMenu.Render(storeService);

                if (nextMenu.Handler != null)
                {
                    nextMenu = Activator.CreateInstance(nextMenu.Handler) as View;
                }
                else
                {
                    LineRenderer.Success("\n Our store closes. Goodbye!");
                    break;
                }
            }
            while (true);
        }
    }
}
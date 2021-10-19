using System;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public class StoreView
    {
        private View nextMenu;

        public StoreView()
        {
            nextMenu = new StartMenuView();
        }

        public void Init()
        {
            do
            {
                nextMenu.Render();

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
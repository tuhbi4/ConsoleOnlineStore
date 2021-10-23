using System;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View
{
    public class StoreView
    {
        private IView nextView;
        private Type nextViewType;
        private readonly IViewFactory viewFactory;

        public StoreView(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
            nextView = new StartMenuView();
            Console.Title = "Console Online Store";
        }

        public void Init()
        {
            do
            {
                nextView.Render();
                nextViewType = nextView.NextViewType;
                nextView = viewFactory.Create(nextViewType);
            }
            while (nextViewType != null);

            LineRenderer.Success("\n Our store closes. Goodbye!");
        }
    }
}
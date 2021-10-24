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
        private readonly ViewNotifier notifier;

        public StoreView(IViewFactory viewFactory, ViewNotifier notifier)
        {
            this.viewFactory = viewFactory;
            nextView = new StartMenuView();
            Console.Title = "Console Online Store";
            this.notifier = notifier;
        }

        public void Init()
        {
            notifier.OnNotify += HandleNotification;
            do
            {
                nextView.Render();
                nextViewType = nextView.NextViewType;
                nextView = viewFactory.Create(nextViewType);
            }
            while (nextViewType != null);

            LineRenderer.Success("\n Our store closes. Goodbye!");
        }

        public void HandleNotification(string message)
        {
            nextView.SetNotificationMessage(message);
            nextView.Render();
        }
    }
}
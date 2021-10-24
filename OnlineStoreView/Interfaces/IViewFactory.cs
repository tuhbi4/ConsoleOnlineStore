using System;

namespace OnlineStoreView.Interfaces
{
    public interface IViewFactory
    {
        public IView Create(Type type);
    }
}
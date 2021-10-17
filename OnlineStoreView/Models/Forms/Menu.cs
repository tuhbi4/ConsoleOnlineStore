using System;

namespace OnlineStoreView.Models
{
    public abstract class Menu
    {
        public string Header { get; protected set; }
        public Type CalledType { get; protected set; }

        protected Menu(string header)
        {
            Header = header;
        }

        public abstract void Render();
    }
}
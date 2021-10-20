using System;
using ConsoleOnlineStore;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class ConfirmationView : View
    {
        public MenuItemHandler Yes { get; protected set; }

        public MenuItemHandler No { get; protected set; }

        protected ConfirmationView(string header) : base(header) { }

        protected abstract void OnFinish(); // TODO: now uses just in logout menu

        public override void Render(StoreService storeService)
        {
            this.storeService = storeService;

            do
            {
                PrintMenu();
                GetUserInput();
            }
            while (!IsValidUserInput());

            if (Input == 1)
            {
                Handler = Yes.Handler;
            }
            else if (Input == 2)
            {
                Handler = No.Handler;
            }

            OnFinish();
        }

        public override void PrintMenu()
        {
            Console.Clear();
            LineRenderer.Header($" > {Header}\n");
            LineRenderer.Warning($"\nAre you sure you want {Header.ToLowerInvariant()}?\n");
            LineRenderer.Primary($"1. {Yes.Caption}");
            LineRenderer.Primary($"2. {No.Caption}");
            LineRenderer.Secondary("\nEnter the number of your choice:\n");

            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error("\n" + ErrorMessage + "\n");
            }
        }

        public override bool IsValidUserInput()
        {
            if (Input < 1 && Input > 2)
            {
                ErrorMessage = $"Сome on, you can do it! Just {Yes.Caption} or {No.Caption}...";

                return false;
            }

            return true;
        }
    }
}
using System;
using ConsoleOnlineStore;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class View
    {
        public string Header { get; protected set; }

        public Type Handler { get; protected set; }

        public MenuItemHandler Back { get; protected set; }

        protected int Input { get; set; }

        protected string ErrorMessage { get; set; } = string.Empty;

        protected StoreService storeService;

        protected View(string header)
        {
            Header = header;
        }

        public virtual void Render(StoreService storeService)
        {
            this.storeService = storeService;

            do
            {
                PrintMenu();
                GetUserInput();
            }
            while (!IsValidUserInput());
        }

        public virtual void PrintMenu()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            LineRenderer.Secondary($"\n{0}. {Back.Caption}\n");

            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error("\n" + ErrorMessage);
                ErrorMessage = string.Empty;
            }

            LineRenderer.Secondary("\nEnter the number of your choice:");
        }

        public virtual void GetUserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                ErrorMessage = "This is not a number.";
                Input = -1;
            }
            else
            {
                Input = input;
            }
        }

        public virtual bool IsValidUserInput()
        {
            if (Input != 0)
            {
                if (ErrorMessage == string.Empty)
                {
                    ErrorMessage = "Enter correct number.";
                }

                return false;
            }

            return true;
        }
    }
}
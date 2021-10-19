using System;
using System.Collections.Generic;
using OnlineStoreView.Models;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class InputView : View
    {
        public MenuItemHandler Cancel { get; protected set; }
        public List<MenuItem> MenuItems { get; protected set; }
        public Type SuccessHandler { get; protected set; }
        public Type ErrorHandler { get; protected set; }
        protected string StringInput { get; set; }

        protected InputView(string header) : base(header)
        {
        }

        protected abstract void OnFinish(); // TODO: call to core

        protected virtual void OnSuccess()
        {
            Handler = SuccessHandler;
        }

        protected virtual void OnError()
        {
            Handler = ErrorHandler;
        }

        public override void Render()
        {
            var index = 0;
            foreach (MenuItem item in MenuItems)
            {
                do
                {
                    PrintMenu(++index, item);
                    GetUserInput();
                }
                while (!IsValidUserInput());

                if (Input == 1)
                {
                    Handler = Cancel.Handler;
                    break;
                }
            }

            if (Input != 1)
            {
                OnFinish();
            }
        }

        public virtual void PrintMenu(int index, MenuItem item)
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            LineRenderer.Secondary($"\n1. {Cancel.Caption}");
            LineRenderer.Primary($"\n{item.Caption}: ({index}/{MenuItems.Count})\n");
            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error("\n" + ErrorMessage + "\n");
            }
        }

        public override void GetUserInput()
        {
            string stringInput = Console.ReadLine();
            if (!int.TryParse(stringInput, out int result) && result == 1)
            {
                Input = result;
            }

            StringInput = stringInput;
        }

        public override bool IsValidUserInput()
        {
            if (StringInput == string.Empty)
            {
                ErrorMessage = "This field must be filled.";
                return false;
            }

            return true;
        }
    }
}
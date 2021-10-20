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

        public List<string> Inputs { get; protected set; }

        public Type SuccessHandler { get; protected set; }

        public Type ErrorHandler { get; protected set; }

        protected InputView(string header) : base(header) { }

        protected abstract void OnFinish(); // TODO: call to core

        protected virtual void OnSuccess()
        {
            Handler = SuccessHandler;
        }

        protected virtual void OnError(int opCode)
        {
            if (opCode != 1)
            {
                Handler = ErrorHandler;
            }
        }

        public override void Render()
        {
            var index = 0;
            Inputs = new();

            foreach (MenuItem item in MenuItems)
            {
                do
                {
                    PrintMenu(++index, item);
                    GetUserInput();
                }
                while (!IsValidUserInput());

                if (Input == 0)
                {
                    Handler = Cancel.Handler;
                    break;
                }
            }

            if (Input != 0)
            {
                OnFinish();
            }
        }

        public virtual void PrintMenu(int index, MenuItem item)
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header}\n");
            LineRenderer.Secondary($"\n0. {Cancel.Caption}");
            LineRenderer.Primary($"\n{item.Caption}: ({index}/{MenuItems.Count})\n");

            if (ErrorMessage != string.Empty)
            {
                LineRenderer.Error("\n" + ErrorMessage + "\n");
            }
        }

        public override void GetUserInput()
        {
            string stringInput = Console.ReadLine();

            if (stringInput == "0")
            {
                Input = 0;
            }
            else
            {
                Input = -1;
            }

            Inputs.Add(stringInput);
        }

        public override bool IsValidUserInput()
        {
            if (Inputs[^1] == string.Empty)
            {
                ErrorMessage = "This field must be filled.";

                return false;
            }

            return true;
        }
    }
}
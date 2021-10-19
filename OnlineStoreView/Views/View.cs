using System;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.Views
{
    public abstract class View
    {
        public string Header { get; protected set; }

        public Type Handler { get; protected set; }

        protected int Input { get; set; }

        protected string ErrorMessage { get; set; } = string.Empty;

        protected View(string header)
        {
            Header = header;
        }

        public virtual void Render()
        {
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
            }

            Input = input;
        }

        public virtual bool IsValidUserInput()
        {
            if (Input < 1)
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
using System;
using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public abstract class MenuViewModel
    {
        public string Header { get; protected set; }
        public Type Handler { get; protected set; }
        protected int Input { get; set; }
        protected string ErrorMessage { get; set; } = string.Empty;

        protected MenuViewModel(string header)
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
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            if (ErrorMessage != string.Empty)
            {
                PrintLineService.Error("\n" + ErrorMessage);
                ErrorMessage = string.Empty;
            }
            PrintLineService.Secondary("\nEnter the number of your choice:");
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
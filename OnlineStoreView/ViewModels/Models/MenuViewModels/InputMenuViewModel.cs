using System;
using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class InputMenuViewModel : MenuViewModel
    {
        public HandlerMenuItem Cancel { get; protected set; }
        public List<MenuItem> MenuItems { get; protected set; }
        public Type SuccessHandler { get; protected set; }
        public Type ErrorHandler { get; protected set; }
        protected string StringInput { get; set; }

        protected InputMenuViewModel(string header) : base(header)
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
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            PrintLineService.Secondary($"\n1. {Cancel.Caption}");
            PrintLineService.Primary($"\n{item.Caption}: ({index}/{MenuItems.Count})\n");
            if (ErrorMessage != string.Empty)
            {
                PrintLineService.Error("\n" + ErrorMessage + "\n");
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
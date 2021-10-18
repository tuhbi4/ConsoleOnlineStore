using System;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class ConfirmationMenuViewModel : MenuViewModel
    {
        public HandlerMenuItem Yes { get; protected set; }
        public HandlerMenuItem No { get; protected set; }

        protected ConfirmationMenuViewModel(string header) : base(header)
        {
        }

        protected abstract void OnFinish(); // TODO: now uses just in logout menu

        public override void Render()
        {
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
            PrintLineService.Header($" > {Header}\n");
            PrintLineService.Warning($"\nAre you sure you want {Header.ToLowerInvariant()}?\n");
            PrintLineService.Primary($"1. {Yes.Caption}");
            PrintLineService.Primary($"2. {No.Caption}");
            PrintLineService.Secondary("\nEnter the number of your choice:\n");
            if (ErrorMessage != string.Empty)
            {
                PrintLineService.Error("\n" + ErrorMessage + "\n");
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
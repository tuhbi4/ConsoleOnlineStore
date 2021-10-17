using System;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class ConfirmationForm : Menu
    {
        public Link Yes { get; protected set; }
        public Link No { get; protected set; }

        protected ConfirmationForm(string header) : base(header)
        {
        }

        public override void Render()
        {
            var message = string.Empty;
            var validatorMessage = string.Empty;
            int input;

            do
            {
                input = GetInput(ref message, validatorMessage);
            }
            while (!IsValidAnswer(input, out validatorMessage) || input != 1 && input != 2);

            if (input == 1)
            {
                CalledType = Yes.LinkedMenuType;
            }
            else
            {
                CalledType = No.LinkedMenuType;
            }
        }

        private int GetInput(ref string message, string validatorMessage)
        {
            Console.Clear();
            PrintMenu();
            if (message != null && message.Length != 0)
            {
                PrintColorLineService.Error("\n" + message);
            }
            if (validatorMessage != null && validatorMessage.Length != 0)
            {
                PrintColorLineService.Error(validatorMessage);
            }
            PrintColorLineService.Secondary("\nEnter the number of your choice:");
            message = "Enter correct number.";
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                message = "This is not a number.";
            }

            return input;
        }

        private void PrintMenu()
        {
            PrintColorLineService.Header($" > {Header}\n");
            PrintColorLineService.Warning($"Are you sure you want {Header.ToLowerInvariant()}?\n");
            PrintColorLineService.Primary($"1. {Yes.Caption}");
            PrintColorLineService.Primary($"2. {No.Caption}");
        }

        public virtual bool IsValidAnswer(int input, out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }

        public virtual bool IsValidAnswer(string input, out string errorMessage)
        {
            if (input.Length == 0)
            {
                errorMessage = "This field must be filled.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
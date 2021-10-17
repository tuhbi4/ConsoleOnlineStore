using System;
using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class SelectionForm : Menu
    {
        public List<Span> MenuItems { get; protected set; }

        protected SelectionForm(string header) : base(header)
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
            while (!IsValidAnswer(input, out validatorMessage) || input < 1 || input > MenuItems.Count);

            Link linkItem = MenuItems[input - 1] as Link;
            CalledType = linkItem.LinkedMenuType;
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
            var i = 0;
            foreach (Span item in MenuItems)
            {
                PrintColorLineService.Primary($"{++i}. {item.Caption}");
            }
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
using System;
using System.Collections.Generic;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.Services
{
    public class ConfirmationFormViewModelService : IViewModelService
    {
        public void PrintViewModel(IMenu menu, IValidatorService validator, out object[] result)
        {
            var message = string.Empty;
            var validatorMessage = string.Empty;
            result = new object[1];
            int input;

            do
            {
                input = GetInput(menu, ref message, validatorMessage);
            }
            while (!validator.IsValidAnswer(input, out validatorMessage) || input != 1 && input != 2);

            result[0] = input;
        }

        private int GetInput(IMenu menu, ref string message, string validatorMessage)
        {
            int input;
            Console.Clear();
            PrintMenu(menu.Menu);
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
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                message = "This is not a number.";
            }

            return input;
        }

        private void PrintMenu(List<string> menu)
        {
            PrintColorLineService.Warning($"Are you sure you want {menu[0].ToLowerInvariant()}?\n");
            PrintColorLineService.Primary($"1. Yes");
            PrintColorLineService.Primary($"2. No");
        }
    }
}
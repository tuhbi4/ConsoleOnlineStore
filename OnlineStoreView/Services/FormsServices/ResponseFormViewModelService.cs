using System;
using OnlineStoreView.Interfaces;

namespace OnlineStoreView.Services
{
    public class ResponseFormViewModelService : IViewModelService
    {
        public void PrintViewModel(IMenu menu, IValidatorService validator, out object[] result)
        {
            result = new object[menu.Menu.Count];
            var index = 0;
            foreach (string item in menu.Menu)
            {
                string input;
                var message = string.Empty;
                do
                {
                    Console.Clear();
                    if (message != null && message.Length != 0)
                    {
                        PrintColorLineService.Error(message + "\n");
                    }
                    PrintColorLineService.Primary($"{item}:");
                    input = Console.ReadLine();
                }
                while (!validator.IsValidAnswer(input, out message));
                result[index++] = input;
            }
        }
    }
}
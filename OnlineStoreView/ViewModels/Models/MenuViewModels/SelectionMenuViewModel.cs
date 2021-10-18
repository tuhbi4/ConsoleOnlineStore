using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class SelectionMenuViewModel : MenuViewModel
    {
        public HandlerMenuItem Back { get; protected set; }
        public List<MenuItem> MenuItems { get; protected set; }

        protected SelectionMenuViewModel(string header) : base(header)
        {
        }

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
                Handler = Back.Handler;
            }
            else if (Input > 1 && Input <= MenuItems.Count + 1)
            {
                HandlerMenuItem item = MenuItems[Input - 2] as HandlerMenuItem;
                Handler = item.Handler;
            }
        }

        public override void PrintMenu()
        {
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            var i = 1;
            PrintLineService.Secondary($"\n{i}. {Back.Caption}\n");
            foreach (MenuItem item in MenuItems)
            {
                PrintLineService.Primary($"{++i}. {item.Caption}");
            }
            PrintLineService.Secondary("\nEnter the number of your choice:\n");
            if (ErrorMessage != string.Empty)
            {
                PrintLineService.Error(ErrorMessage + "\n");
                ErrorMessage = string.Empty;
            }
        }

        public override bool IsValidUserInput()
        {
            if (Input < 1 || Input > MenuItems.Count + 1)
            {
                if (ErrorMessage == string.Empty)
                {
                    ErrorMessage = "We understand that it is very difficult to make a choice, but you must try again! :).";
                }

                return false;
            }

            return true;
        }
    }
}
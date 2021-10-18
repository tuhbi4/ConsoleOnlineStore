using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class RepositorySelectionMenuViewModel : SelectionMenuViewModel
    {
        public new List<HandlerMenuItem> MenuItems { get; protected set; }

        protected RepositorySelectionMenuViewModel(string header) : base(header)
        {
        }

        protected abstract void OnInit(); // TODO: call to core
        protected abstract void OnFinish(); // TODO: call to core

        public override void Render()
        {
            OnInit();

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
            else if (Input > 1 && Input < MenuItems.Count + 1)
            {
                Handler = MenuItems[Input - 2].Handler;
            }
        }

        public override void PrintMenu()
        {
            PrintLineService.Clear();
            PrintLineService.Header($" > {Header}\n");
            var i = 0;
            PrintLineService.Secondary($"\n{++i}. {Back.Caption}\n");
            foreach (HandlerMenuItem item in MenuItems)
            {
                PrintLineService.Primary($"{++i}. {item.Caption}");
            }
            PrintLineService.Secondary("\nEnter the number of your choice:\n");
        }
    }
}
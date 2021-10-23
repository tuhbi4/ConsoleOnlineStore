using System;
using System.Collections.Generic;
using OnlineStoreView.Models.MenuItems;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.View.Views.InputViews
{
    public abstract class InputView : View
    {
        protected List<InputItem> MenuItems { get; set; }

        protected int currentItemIndex;

        public override void Render()
        {
            currentItemIndex = 0;
            inputPromptMessage = "Enter your answer or \"0\" to cancel:";
            BeforePrintMenu();

            foreach (var _ in MenuItems)
            {
                PrintMenu();
                Input = GetUserInput();

                if (Input == 0)
                {
                    break;
                }

                currentItemIndex++;
            }

            OnFinish();
            NextViewType = GetNextViewType();
        }

        protected override void PrintBody()
        {
            if (MenuItems != null)
            {
                if (MenuItems.Count > 1)
                {
                    LineRenderer.Primary($"\n{MenuItems[currentItemIndex].Caption}: ({currentItemIndex + 1}/{MenuItems.Count})");
                }
                else
                {
                    LineRenderer.Primary($"\n{MenuItems[currentItemIndex].Caption}:");
                }
            }
        }

        protected override int GetUserInput()
        {
            MenuItems[currentItemIndex].SetInput(string.Empty);
            string inputText = Console.ReadLine();

            if (int.TryParse(inputText, out int input))
            {
                if (inputText == "0")
                {
                    return input;
                }
                else if (MenuItems != null && MenuItems.Count > 0)
                {
                    MenuItems[currentItemIndex].SetInput(inputText);
                }
            }

            return -1;
        }
    }
}
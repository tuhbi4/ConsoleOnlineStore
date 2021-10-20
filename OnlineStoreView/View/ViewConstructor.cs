using System;
using System.Collections.Generic;

namespace OnlineStoreView.ZView
{
    public enum ViewType
    {
        StartMenu = 1,
        MainMenu,
        AuthorizationMenu,
        RegistrationMenu,
        //TODO: add 
    }

    public abstract class ViewBuilder
    {
        private ViewType menuType;

        private readonly Header header;
        private readonly MenuItemHandler back;
        private readonly MenuItemHandler yes;
        private readonly MenuItemHandler no;
        private readonly List<MenuItemHandler> menuItemHandlers;
        private readonly InputItem inputItem;
        private readonly List<InputItem> inputItems;
        private readonly List<MenuItem> menuItems;
        private readonly MenuItemHandler buy;
        private readonly MenuItemHandler clear;

        private readonly bool isHeaderNeed;
        private readonly bool isBackNeed;
        private readonly bool isConfirmationNeed;
        private readonly bool isYesNeed;
        private readonly bool isNoNeed;
        private readonly bool isMenuItemsNeed;
        private readonly bool isInputItemNeed;
        private readonly bool isInputItemsNeed;
        private readonly bool isBuyNeed;
        private readonly bool isClearNeed;

        private string errorMessage;
        private int input;
        private int maxItemIndex;
        private string stringInput;
        private List<string> stringInputs;

        //protected ViewBuilder(ViewType menuType)
        //{
        //    this.menuType = menuType;
        //    Build();
        //}
        private ViewBuilder(Header header)
        {
            this.header = header;
            isHeaderNeed = true;
        }

        private ViewBuilder(Header header, MenuItemHandler back) : this(header)
        {
            this.back = back;
            isBackNeed = true;
        }

        protected ViewBuilder(Header header, MenuItemHandler back, List<MenuItemHandler> menuItemHandlers) : this(header, back)
        {
            this.menuItemHandlers = menuItemHandlers;
            isMenuItemsNeed = true;
            maxItemIndex = menuItems.Count;
        }

        protected ViewBuilder(Header header, MenuItemHandler yes, MenuItemHandler no) : this(header)
        {
            this.yes = yes;
            this.no = no;
            isConfirmationNeed = true;
            isYesNeed = true;
            isNoNeed = true;
            maxItemIndex = 2;
        }

        protected ViewBuilder(Header header, MenuItemHandler back, InputItem inputItem) : this(header, back)
        {
            this.inputItem = inputItem;
            isInputItemNeed = true;
            maxItemIndex = 0;
        }

        protected ViewBuilder(Header header, MenuItemHandler back, List<InputItem> inputItems) : this(header, back)
        {
            this.inputItems = inputItems;
            isInputItemsNeed = true;
            maxItemIndex = inputItems.Count;
        }

        protected ViewBuilder(Header header, MenuItemHandler back, List<MenuItemHandler> menuItems, MenuItemHandler buy, MenuItemHandler clear) : this(header, back, menuItems)
        {
            this.buy = buy;
            this.clear = clear;
            isBuyNeed = true;
            isClearNeed = true;
            maxItemIndex = inputItems.Count + 2;
        }

        protected virtual void Build()
        {
            OnInit();

            do
            {
                PrintMenu();

                if (isInputItemNeed)
                {
                    stringInput = GetUserStringInput(out input);
                }
                else if (isInputItemsNeed)
                {
                    stringInputs = GetUserStringInputs(out input);
                }
                else
                {
                    input = GetUserInput();
                }
            }
            while (!IsValidUserInput());

            SwitchNextMenu();
            OnFinish();
        }

        protected virtual void PrintMenu()
        {
            if (isHeaderNeed) BuildHeader();
            if (isBackNeed) BuildBack();
            if (isConfirmationNeed) BuildConfirmation();
            if (isYesNeed) BuildYes();
            if (isNoNeed) BuildNo();
            if (isMenuItemsNeed) BuildMenuItems();
            if (isInputItemNeed) BuildInputItem();
            if (isInputItemsNeed) BuildInputItems();
            BuildErrorMessage();
            BuildInputPrompt();
        }

        protected abstract void OnInit();

        protected virtual void BuildHeader()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {header.Text}\n");
        }

        protected virtual void BuildBack()
        {
            LineRenderer.Secondary($"\n{0}. {back.Caption}\n");
        }

        protected virtual void BuildConfirmation()
        {
            LineRenderer.Warning($"\nAre you sure you want {header.Text.ToLowerInvariant()}?\n");
        }

        protected virtual void BuildYes()
        {
            LineRenderer.Primary($"1. {yes.Caption}");
        }

        protected virtual void BuildNo()
        {
            LineRenderer.Primary($"2. {no.Caption}");
        }

        protected virtual void BuildMenuItems()
        {
            var i = 0;

            foreach (MenuItem item in menuItems)
            {
                if (isInputItemNeed)
                {
                    LineRenderer.Primary($"\n{item.Caption}:\n");
                }
                else if (isInputItemsNeed)
                {
                    LineRenderer.Primary($"\n{item.Caption}: ({++i}/{menuItems.Count})\n");
                }
                else
                {
                    LineRenderer.Primary($"{++i}. {item.Caption}");
                }
            }
        }

        protected virtual void BuildInputItem()
        {
            //TODO: add implementation
        }

        protected virtual void BuildInputItems()
        {
            //TODO: add implementation
        }

        protected virtual void BuildErrorMessage()
        {
            if (errorMessage != string.Empty)
            {
                LineRenderer.Error("\n" + errorMessage);
                errorMessage = string.Empty;
            }
        }

        protected virtual void BuildInputPrompt()
        {
            LineRenderer.Secondary("\nEnter the number of your choice:\n");
        }

        protected virtual int GetUserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                errorMessage = "This is not a number.";

                return -1;
            }
            else
            {
                return input;
            }
        }

        protected virtual string GetUserStringInput(out int input)
        {
            string textInput = Console.ReadLine();

            if (textInput == "0")
            {
                input = 0;

                return string.Empty;
            }
            else
            {
                input = -1;
            }

            return textInput;
        }

        protected virtual List<string> GetUserStringInputs(out int input)
        {
            List<string> textInputs = new();

            foreach (InputItem item in inputItems)
            {
                string textInput = Console.ReadLine();

                if (textInput == "0")
                {
                    input = 0;

                    return textInputs;
                }
                else
                {
                    input = -1;
                }

                textInputs.Add(textInput);
            }

            input = -1;

            return textInputs;
        }

        protected virtual bool IsValidUserInput()
        {
            if (input < 0 && input > maxItemIndex)
            {
                if (isConfirmationNeed)
                {
                    errorMessage = $"Сome on, you can do it! Just {yes.Caption} or {no.Caption}...";
                }

                return false;
            }

            return true;
        }

        protected virtual void SwitchNextMenu()
        {
            if (input == 0)
            {
                menuType = back.NextView;
            }
            if (input == 1)
            {
                menuType = yes.NextView;
            }
            if (input == 2)
            {
                menuType = no.NextView;
            }
            else if (input > 0 && input <= menuItemHandlers.Count)
            {
                menuType = menuItemHandlers[input - 1].NextView;
            }
            else if (input == menuItemHandlers.Count + 1)
            {
                menuType = buy.NextView;
            }
            else if (input == menuItemHandlers.Count + 2)
            {
                menuType = clear.NextView;
            }
        }

        protected abstract void OnFinish();
    }
}
using System;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.View.Views
{
    public abstract class View : IView
    {
        public Type NextViewType { get; protected set; }

        protected Header Header { get; set; }

        protected MenuItemHandler Back { get; set; }

        protected int MaxItemIndex { get; set; }

        protected string WrongIndexMessage { get; set; }

        protected int Input { get; set; }

        private int minItemIndex = 0;
        protected const string wrongInputMessage = "This is not a number.";
        protected string inputPromptMessage = "Enter the number of your choice:";
        protected bool isWrongInput;
        protected bool isWrongIndex;

        public virtual void Render()
        {
            if (Back == null)
            {
                minItemIndex = 1;
            }
            else
            {
                minItemIndex = 0;
            }

            do
            {
                BeforePrintMenu();
                PrintMenu();
                Input = GetUserInput();
            }
            while (!IsValidUserInput());

            OnFinish();

            NextViewType = GetNextViewType();
        }

        protected abstract void BeforePrintMenu();

        protected virtual void PrintMenu()
        {
            if (Header != null)
            {
                PrintHeader();
            }

            if (Back != null)
            {
                PrintBack();
            }

            PrintBody();

            if (WrongIndexMessage != null && (isWrongInput || isWrongIndex))
            {
                PrintErrorMessage();
            }

            if (inputPromptMessage != null)
            {
                PrintInputPrompt();
            }
        }

        protected abstract void PrintBody();

        protected virtual int GetUserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                isWrongInput = true;

                return -1;
            }

            return input;
        }

        protected bool IsValidUserInput()
        {
            if (Input >= minItemIndex && Input <= MaxItemIndex)
            {
                return true;
            }

            isWrongIndex = true;

            return false;
        }

        protected abstract void OnFinish();

        protected Type GetNextViewType()
        {
            if (Back != null && Input == minItemIndex)
            {
                return Back.NextViewType;
            }

            return GetNextViewTypeWhenIsNotBackItem();
        }

        protected abstract Type GetNextViewTypeWhenIsNotBackItem();

        protected virtual void PrintHeader()
        {
            LineRenderer.Clear();
            LineRenderer.Header($" > {Header.Text}\n");
        }

        protected virtual void PrintBack()
        {
            LineRenderer.Secondary($"\n{minItemIndex}. {Back.Caption}");
        }

        protected virtual void PrintErrorMessage()
        {
            if (isWrongInput)
            {
                LineRenderer.Error($"\n{wrongInputMessage}");
                isWrongInput = false;
            }
            else if (isWrongIndex)
            {
                LineRenderer.Error($"\n{WrongIndexMessage}");
                isWrongIndex = false;
            }
        }

        protected virtual void PrintInputPrompt()
        {
            LineRenderer.Secondary($"\n{inputPromptMessage}\n");
        }
    }
}
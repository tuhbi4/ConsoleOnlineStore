using System;
using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class ResponseForm : Menu
    {
        public List<Span> MenuItems { get; protected set; }
        public Type LinkedSuccessMenu { get; protected set; }
        public Type LinkedErrorMenu { get; protected set; }

        protected ResponseForm(string header) : base(header)
        {
        }

        protected abstract void OnFinish();

        protected virtual void OnError()
        {
            CalledType = LinkedErrorMenu; // TODO: implement call to account repository with error
        }

        public override void Render()
        {
            foreach (Span item in MenuItems)
            {
                string input;
                var message = string.Empty;
                do
                {
                    Console.Clear();
                    PrintColorLineService.Header($" > {Header}\n");
                    if (message != null && message.Length != 0)
                    {
                        PrintColorLineService.Error(message + "\n");
                    }
                    PrintColorLineService.Primary($"{item.Caption}:");
                    input = Console.ReadLine();
                }
                while (!IsValidAnswer(input, out message));

                OnFinish();
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

        public virtual bool IsValidAnswer(string login, string password, out string errorMessage)
        {
            if (login.Length == 0)
            {
                errorMessage = "Login must be specified.";
                return false;
            }
            if (password.Length == 0)
            {
                errorMessage = "Password must be specified.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
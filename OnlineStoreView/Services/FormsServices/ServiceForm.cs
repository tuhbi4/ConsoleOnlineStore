﻿using System;
using System.Collections.Generic;
using OnlineStoreView.Models;

namespace OnlineStoreView.Services
{
    public abstract class ServiceForm : Menu
    {
        public List<Span> MenuItems { get; protected set; }
        public Link Back { get; protected set; }

        protected ServiceForm(string header) : base(header)
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
            while (!IsValidAnswer(input, out validatorMessage) || input < 1 || input > MenuItems.Count + 1);


            if (input == MenuItems.Count + 1)
            {
                CalledType = Back.LinkedMenuType;
            }
            else
            {
                Link linkItem = MenuItems[input - 1] as Link;
                CalledType = linkItem.LinkedMenuType;
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
            PrintColorLineService.Primary("<Content>\n"); // TODO: implement the content output and think over the controls
            int i;
            for (i = 1; i <= MenuItems.Count; i++)
            {
                PrintColorLineService.Information($"{i}. {MenuItems[i - 1].Caption}");
            }
            PrintColorLineService.Information($"{i}. {Back.Caption}");
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
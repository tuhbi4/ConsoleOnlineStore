using System;
using ConsoleOnlineStore;
using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public class ProductQuantityInputView : InputView
    {
        private const string header = "Aadding a product to the basket";

        public ProductQuantityInputView() : base(header)
        {
            Cancel = new MenuItemHandler("Cancel", typeof(CatalogView));
            MenuItems = new()
            {
                new MenuItem("Enter quantity"),
            };
            SuccessHandler = typeof(CatalogView);
            ErrorHandler = typeof(ProductQuantityInputView);
        }

        protected override void OnFinish()
        {
            int opCode = StoreService.TryAddProductToBasket(Input);
            if (opCode > 0)
            {
                OnSuccess();
            }
            else
            {
                OnError(opCode);
            }
        }

        public override void GetUserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                ErrorMessage = "This is not a number.";
            }

            Input = input;
        }

        public override bool IsValidUserInput()
        {
            if (Input < 1)
            {
                if (ErrorMessage == string.Empty)
                {
                    ErrorMessage = "Enter correct number. Quantity cannot be less than 1.";
                }

                return false;
            }

            return true;
        }
    }
}
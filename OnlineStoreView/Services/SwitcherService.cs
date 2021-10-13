using System;
using OnlineStoreView.Interfaces;
using OnlineStoreView.ViewModels;

namespace OnlineStoreView.Services
{
    public class SwitcherService
    {
        private IMenu nextMenu;
        private IValidatorService validator;
        private IViewModelService menuService;
        private object[] result;
        private bool IsExit = false;

        private readonly LoginMenuSelectionFormViewModel loginMenu = new();
        private readonly AuthorizationFormViewModel authorizationMenu = new();
        private readonly RegistrationFormViewModel registrationMenu = new();
        private readonly MainMenuSelectionFormsViewModel mainMenu = new();
        private readonly CatalogServiceFormViewModel catalogService = new();
        private readonly BasketServiceFormViewModel basketService = new();
        private readonly OrderHistoryServiceFormViewModel orderHistoryService = new();
        private readonly LogoutMenuViewModel logoutMenu = new();
        private readonly ExitMenuViewModel exitMenu = new();

        private readonly DefaultFormValidatorService defaultValidator = new();
        private readonly AuthorizationFormValidatorService authorizationValidator = new();
        private readonly RegistrationFormValidatorService registrationValidator = new();

        private readonly SelectionFormViewModelService selectionForm = new();
        private readonly ResponseFormViewModelService responseForm = new();
        private readonly ServiceFormViewModelService serviceForm = new();
        private readonly ConfirmationFormViewModelService confirmationForm = new();

        public void StartInit()
        {
            nextMenu = loginMenu;
            validator = defaultValidator;
            menuService = selectionForm;
            InitMenu();
        }

        public void InitMenu()
        {
            do
            {
                menuService.PrintViewModel(nextMenu, validator, out result);
                if (menuService != responseForm)
                {
                    SwitchSwitcher((int)result[0]);
                }
                else
                {
                    SwitchSwitcher(-1); // TODO: try to implement something better
                }
            }
            while (!IsExit);
        }

        private void SwitchSwitcher(int userChoice)
        {
            switch (true)
            {
                case true when nextMenu == loginMenu:
                    SwitchFromLoginMenu(userChoice);
                    break;

                case true when nextMenu == authorizationMenu:
                    SwitchFromAuthorizationMenu(userChoice);
                    break;

                case true when nextMenu == registrationMenu:
                    SwitchFromRegistrationMenu(userChoice);
                    break;

                case true when nextMenu == mainMenu:
                    SwitchFromMainMenu(userChoice);
                    break;

                case true when nextMenu == catalogService:
                    SwitchFromCatalogMenu(userChoice);
                    break;

                case true when nextMenu == basketService:
                    SwitchFromBasketMenu(userChoice);
                    break;

                case true when nextMenu == orderHistoryService:
                    SwitchFromOrderHistoryMenu(userChoice);
                    break;

                case true when nextMenu == logoutMenu:
                    SwitchFromLogoutMenu(userChoice);
                    break;

                case true when nextMenu == exitMenu:
                    SwitchFromExitMenu(userChoice);
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromLoginMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    nextMenu = authorizationMenu;
                    validator = authorizationValidator;
                    menuService = responseForm;
                    break;

                case 2:
                    nextMenu = registrationMenu;
                    validator = registrationValidator;
                    menuService = responseForm;
                    break;

                case 3:
                    nextMenu = exitMenu;
                    validator = defaultValidator;
                    menuService = confirmationForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromAuthorizationMenu(int userChoice)
        {
            // TODO: implement transition to Account.Login()
            nextMenu = mainMenu;
            validator = defaultValidator;
            menuService = selectionForm;
        }

        private void SwitchFromRegistrationMenu(int userChoice)
        {
            // TODO: implement transition to Account.Register()
            nextMenu = mainMenu;
            validator = defaultValidator;
            menuService = selectionForm;
        }

        private void SwitchFromMainMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    nextMenu = catalogService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 2:
                    nextMenu = basketService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 3:
                    nextMenu = orderHistoryService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 4:
                    nextMenu = logoutMenu;
                    validator = defaultValidator;
                    menuService = confirmationForm;
                    break;

                case 5:
                    nextMenu = loginMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromCatalogMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                case 2: // TODO: try to implement something better
                    nextMenu = catalogService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 3:
                    nextMenu = mainMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromBasketMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                case 2: // TODO: try to implement something better
                    nextMenu = basketService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 3:
                    nextMenu = mainMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromOrderHistoryMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                case 2: // TODO: try to implement something better
                    nextMenu = orderHistoryService;
                    validator = defaultValidator;
                    menuService = serviceForm;
                    break;

                case 3:
                    nextMenu = mainMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromLogoutMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    nextMenu = loginMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                case 2:
                    nextMenu = mainMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }

        private void SwitchFromExitMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    IsExit = true;
                    break;

                case 2:
                    nextMenu = loginMenu;
                    validator = defaultValidator;
                    menuService = selectionForm;
                    break;

                default: throw new ArgumentException("Invalid operation code");
            }
        }
    }
}
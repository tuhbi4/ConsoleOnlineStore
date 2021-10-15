using OnlineStoreView.Interfaces;

namespace OnlineStoreView.Services
{
    public class DefaultFormValidatorService : IValidatorService
    {
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
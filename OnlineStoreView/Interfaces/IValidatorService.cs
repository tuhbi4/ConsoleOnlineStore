namespace OnlineStoreView.Interfaces
{
    public interface IValidatorService
    {
        public bool IsValidAnswer(int input, out string errorMessage);

        public bool IsValidAnswer(string input, out string errorMessage);
    }
}
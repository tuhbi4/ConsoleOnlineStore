namespace OnlineStoreView.Interfaces
{
    public interface IViewModelService
    {
        public void PrintViewModel(IMenu menu, IValidatorService validator, out object[] result);
    }
}
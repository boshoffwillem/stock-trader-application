namespace TradingApplication.WPF.ViewModels.Factories
{
    public interface ITradingApplicationViewModelFactory<T> where T : BaseViewModel
    {
        T CreateViewModel();         
    }
}
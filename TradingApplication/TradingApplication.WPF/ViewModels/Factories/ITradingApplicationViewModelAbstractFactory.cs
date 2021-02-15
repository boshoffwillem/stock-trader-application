using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels.Factories
{
    public interface ITradingApplicationViewModelAbstractFactory
    {
         BaseViewModel CreateViewModel(ViewType viewType);
    }
}
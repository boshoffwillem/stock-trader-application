using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels.Factories
{
    public interface IRootTradingApplicationViewModelFactory
    {
         BaseViewModel CreateViewModel(ViewType viewType);
    }
}
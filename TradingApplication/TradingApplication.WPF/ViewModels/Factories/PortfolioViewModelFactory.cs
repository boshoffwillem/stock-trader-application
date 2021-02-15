namespace TradingApplication.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : ITradingApplicationViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}
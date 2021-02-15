using System;
using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels.Factories
{
    public class TradingApplicationViewModelAbstractFactory : ITradingApplicationViewModelAbstractFactory
    {
        private readonly ITradingApplicationViewModelFactory<HomeViewModel> homeViewModelFactory;
        private readonly ITradingApplicationViewModelFactory<PortfolioViewModel> portfolioViewModelFactory;

        public TradingApplicationViewModelAbstractFactory(
            ITradingApplicationViewModelFactory<HomeViewModel> homeViewModelFactory, 
            ITradingApplicationViewModelFactory<PortfolioViewModel> portfolioViewModelFactory = null)
        {
            this.homeViewModelFactory = homeViewModelFactory;
            this.portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
               case ViewType.Home:
                  return homeViewModelFactory.CreateViewModel();
               case ViewType.Portfolio:
                  return portfolioViewModelFactory.CreateViewModel();
               default:
                  throw new ArgumentException("The view type does not have a view model.", "viewType");
            }
        }
    }
}
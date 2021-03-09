using System;
using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels.Factories
{
    public class RootTradingApplicationViewModelFactory : IRootTradingApplicationViewModelFactory
    {
        private readonly ITradingApplicationViewModelFactory<HomeViewModel> homeViewModelFactory;
        private readonly ITradingApplicationViewModelFactory<PortfolioViewModel> portfolioViewModelFactory;
        private readonly BuyViewModel buyViewModel;

        public RootTradingApplicationViewModelFactory(
            ITradingApplicationViewModelFactory<HomeViewModel> homeViewModelFactory, 
            ITradingApplicationViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            BuyViewModel buyViewModel)
        {
            this.homeViewModelFactory = homeViewModelFactory;
            this.portfolioViewModelFactory = portfolioViewModelFactory;
            this.buyViewModel = buyViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
               case ViewType.Home:
                  return homeViewModelFactory.CreateViewModel();
               case ViewType.Portfolio:
                  return portfolioViewModelFactory.CreateViewModel();
               case ViewType.Buy:
                   return buyViewModel;
               default:
                  throw new ArgumentException("The view type does not have a view model.", "viewType");
            }
        }
    }
}
namespace TradingApplication.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ITradingApplicationViewModelFactory<HomeViewModel>
    {
        private readonly ITradingApplicationViewModelFactory<MajorIndexListingViewModel> majorIndexViewModelFactory;

        public HomeViewModelFactory(ITradingApplicationViewModelFactory<MajorIndexListingViewModel> majorIndexViewModelFactory)
        {
            this.majorIndexViewModelFactory = majorIndexViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(majorIndexViewModelFactory.CreateViewModel());
        }
    }
}
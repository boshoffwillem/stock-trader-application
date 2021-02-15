using TradingApplication.Domain.Services;

namespace TradingApplication.WPF.ViewModels.Factories
{
    public class MajorIndexListingViewModelFactory : ITradingApplicationViewModelFactory<MajorIndexListingViewModel>
    {
        private readonly IMajorIndexService majorIndexService;

        public MajorIndexListingViewModelFactory(IMajorIndexService majorIndexService)
        {
            this.majorIndexService = majorIndexService;
        }

        public MajorIndexListingViewModel CreateViewModel()
        {
            return MajorIndexListingViewModel.LoadMajorIndexViewModel(majorIndexService);
        }
    }
}
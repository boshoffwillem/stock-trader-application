namespace TradingApplication.WPF.ViewModels
{
   public class HomeViewModel : BaseViewModel
   {
      public MajorIndexListingViewModel MajorIndexListingViewModel { get; private set; }

      public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
      {
         MajorIndexListingViewModel = majorIndexListingViewModel;
      }

   }
}

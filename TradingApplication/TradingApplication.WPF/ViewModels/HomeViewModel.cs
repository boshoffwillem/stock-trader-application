namespace TradingApplication.WPF.ViewModels
{
   public class HomeViewModel : BaseViewModel
   {
      public MajorIndexViewModel MajorIndexViewModel { get; private set; }

      public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
      {
         MajorIndexViewModel = majorIndexViewModel;
      }

   }
}

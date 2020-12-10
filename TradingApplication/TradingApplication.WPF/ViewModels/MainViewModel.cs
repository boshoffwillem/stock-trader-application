using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels
{
   public class MainViewModel : BaseViewModel
   {
      public INavigator Navigator { get; set; } = new Navigator();
   }
}

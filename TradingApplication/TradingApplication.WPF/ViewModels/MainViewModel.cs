using TradingApplication.WPF.State.Navigators;

namespace TradingApplication.WPF.ViewModels
{
   public class MainViewModel : BaseViewModel
   {
      public INavigator Navigator { get; set; }

      public MainViewModel(INavigator navigator)
      {
         Navigator = navigator;
         Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
      }
   }
}

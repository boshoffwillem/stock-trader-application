using System.Windows.Input;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF.State.Navigators
{
   public enum ViewType
   {
      Home,
      Portfolio
   }

   public interface INavigator
   {
      BaseViewModel CurrentViewModel { get; set; }

      ICommand UpdateCurrentViewModelCommand { get; }
   }
}

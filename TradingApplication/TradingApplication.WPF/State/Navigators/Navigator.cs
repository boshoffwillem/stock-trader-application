using System.Windows.Input;
using TradingApplication.WPF.Commands;
using TradingApplication.WPF.Models;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF.State.Navigators
{
   public class Navigator : ObservableObject, INavigator
   {
      private BaseViewModel currentViewModel;

      public BaseViewModel CurrentViewModel
      {
         get { return currentViewModel; }
         set
         { 
            currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
         }
      }


      public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
   }
}

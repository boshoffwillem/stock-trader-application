using System;
using System.Windows.Input;
using TradingApplication.WPF.State.Navigators;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF.Commands
{
   public class UpdateCurrentViewModelCommand : ICommand
   {
      private INavigator navigator;

      public event EventHandler CanExecuteChanged;

      public UpdateCurrentViewModelCommand(INavigator navigator)
      {
         this.navigator = navigator;
      }

      public bool CanExecute(object parameter)
      {
         return true;
      }

      public void Execute(object parameter)
      {
         if (parameter is ViewType viewType)
         {
            switch (viewType)
            {
               case ViewType.Home:
                  navigator.CurrentViewModel = new HomeViewModel();
                  break;
               case ViewType.Portfolio:
                  navigator.CurrentViewModel = new PortfolioViewModel();
                  break;
               default:
                  break;
            }
         }
      }
   }
}
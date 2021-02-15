using System;
using System.Windows.Input;
using TradingApplication.FinancialModellingPrepApi.Services;
using TradingApplication.WPF.State.Navigators;
using TradingApplication.WPF.ViewModels;
using TradingApplication.WPF.ViewModels.Factories;

namespace TradingApplication.WPF.Commands
{
   public class UpdateCurrentViewModelCommand : ICommand
   {
      private readonly INavigator navigator;
      private readonly ITradingApplicationViewModelAbstractFactory viewModelAbstractFactory;

      public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator, ITradingApplicationViewModelAbstractFactory viewModelAbstractFactory)
        {
            this.navigator = navigator;
            this.viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public bool CanExecute(object parameter)
      {
         return true;
      }

      public void Execute(object parameter)
      {
         if (parameter is ViewType viewType)
         {
            navigator.CurrentViewModel = viewModelAbstractFactory.CreateViewModel(viewType);
         }
      }
   }
}
﻿using System;
using System.Windows.Input;
using TradingApplication.FinancialModellingPrepApi.Services;
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
                  navigator.CurrentViewModel = new HomeViewModel(MajorIndexViewModel.LoadMajorIndexViewModel(new MajorIndexService()));
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
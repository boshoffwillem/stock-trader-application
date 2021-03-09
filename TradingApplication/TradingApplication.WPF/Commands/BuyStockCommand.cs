using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services.TransactionServices;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private readonly BuyViewModel buyViewModel;
        private readonly IBuyStockService buyStockService;

        public event EventHandler CanExecuteChanged;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            this.buyViewModel = buyViewModel;
            this.buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var account = await buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }, buyViewModel.Symbol, buyViewModel.SharesToBuy);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

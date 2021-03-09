using System;
using System.Windows;
using System.Windows.Input;
using TradingApplication.Domain.Services;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private readonly BuyViewModel buyViewModel;
        private readonly IStockPriceService stockPriceService;

        public event EventHandler CanExecuteChanged;

        public SearchSymbolCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService)
        {
            this.buyViewModel = buyViewModel;
            this.stockPriceService = stockPriceService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var stockPrice = await stockPriceService.GetPrice(buyViewModel.Symbol);
                buyViewModel.StockPrice = stockPrice;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

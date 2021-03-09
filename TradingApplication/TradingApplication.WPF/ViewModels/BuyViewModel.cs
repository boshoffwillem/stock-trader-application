using System.Windows.Input;
using System.Windows.Navigation;
using TradingApplication.Domain.Services;
using TradingApplication.Domain.Services.TransactionServices;
using TradingApplication.WPF.Commands;

namespace TradingApplication.WPF.ViewModels
{
    public class BuyViewModel : BaseViewModel
    {
        private string symbol;
        public string Symbol
        {
            get => symbol;
            set
            {
                symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private double stockPrice;
        public double StockPrice
        {
            get => stockPrice;
            set
            {
                stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
            }
        }

        private int sharesToBuy;
        public int SharesToBuy
        {
            get => sharesToBuy;
            set
            {
                sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => SharesToBuy * StockPrice;

        public ICommand SearchSymbolCommand { get; set; }

        public ICommand BuyStockCommand { get; set; }

        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
        }
    }
}

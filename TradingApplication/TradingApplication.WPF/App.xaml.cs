using System.Windows;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;
using TradingApplication.Domain.Services.TransactionServices;
using TradingApplication.EntityFramework;
using TradingApplication.EntityFramework.Services;
using TradingApplication.FinancialModellingPrepApi.Services;
using TradingApplication.WPF.ViewModels;

namespace TradingApplication.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            IStockPriceService stockPriceService = new StockPriceService();
            IDataService<Account> accountService = new AccountDataService(new TradingApplicationDbContextFactory());
            IBuyStockService buyStockService = new BuyStockService(stockPriceService, accountService);
            Account buyer = await accountService.Get(1);
            await buyStockService.BuyStock(buyer, "T", 5);
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}

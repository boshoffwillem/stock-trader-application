using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;
using TradingApplication.Domain.Services.TransactionServices;
using TradingApplication.EntityFramework;
using TradingApplication.EntityFramework.Services;
using TradingApplication.FinancialModellingPrepApi.Services;
using TradingApplication.WPF.State.Navigators;
using TradingApplication.WPF.ViewModels;
using TradingApplication.WPF.ViewModels.Factories;

namespace TradingApplication.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<TradingApplicationDbContextFactory>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();
            services.AddSingleton<IRootTradingApplicationViewModelFactory, RootTradingApplicationViewModelFactory>();
            services.AddSingleton<ITradingApplicationViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ITradingApplicationViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<ITradingApplicationViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();
            services.AddScoped<BuyViewModel>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}

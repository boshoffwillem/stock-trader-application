using System;
using System.Threading.Tasks;
using TradingApplication.Domain.Exceptions;
using TradingApplication.Domain.Models;

namespace TradingApplication.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService stockPriceService;
        private readonly IDataService<Account> accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            this.stockPriceService = stockPriceService;
            this.accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            var stockPrice = await stockPriceService.GetPrice(symbol);
            var transactionPrice = stockPrice * shares;

            if (transactionPrice > buyer.Balance)
            {
                throw new InsufficientFundsException(buyer.Balance, transactionPrice);
            }

            var transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchased = true
            };

            buyer.AssetTransactions.Add(transaction);
            buyer.Balance -= transactionPrice;
            await accountService.Update(buyer.Id, buyer);
            return buyer;
        }
    }
}

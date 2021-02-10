using System.Threading.Tasks;
using TradingApplication.Domain.Models;

namespace TradingApplication.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }
}

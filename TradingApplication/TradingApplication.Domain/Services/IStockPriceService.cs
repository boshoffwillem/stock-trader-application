using System.Threading.Tasks;

namespace TradingApplication.Domain.Services
{
    public interface IStockPriceService
    {
        Task<double> GetPrice(string symbol);
    }
}

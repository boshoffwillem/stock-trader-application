using System.Collections.Generic;
using System.Threading.Tasks;
using TradingApplication.Domain.Exceptions;
using TradingApplication.Domain.Services;
using TradingApplication.FinancialModellingPrepApi.Results;

namespace TradingApplication.FinancialModellingPrepApi.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            var output = 0.0;

            using (var client = new FinancialApiHttpClient())
            {
                var uri = $"quote/{symbol}?apikey=3acf6a88f8fb3a2f2f7ac1f9522f4cf3";
                var results = await client.GetAsync<IEnumerable<StockPriceResult>>(uri);

                if (results?.GetEnumerator() != null)
                {
                    var enumerator = results.GetEnumerator();
                    enumerator.MoveNext();
                    var result = enumerator.Current;

                    if (result is not null)
                        output = result.Price;
                }

                if (output == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return output;
            }
        }
    }
}

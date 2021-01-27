using System.Collections.Generic;
using System.Threading.Tasks;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;

namespace TradingApplication.FinancialModellingPrepApi.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<IEnumerable<MajorIndex>> GetMajorIndices()
        {
            using (var client = new FinancialApiHttpClient())
            {
                var uri = "quote/%5EGSPC,%5EDJI,%5EIXIC?apikey=3acf6a88f8fb3a2f2f7ac1f9522f4cf3";
                var majorIndices = await client.GetAsync<IEnumerable<MajorIndex>>(uri);

                foreach (var index in majorIndices)
                {
                    if (index.Symbol.ToUpper().Contains("DJI"))
                    {
                        index.Type = MajorIndexType.DowJones;
                    }
                    else if (index.Symbol.ToUpper().Contains("GSPC"))
                    {
                        index.Type = MajorIndexType.SP500;
                    }
                    else if (index.Symbol.ToUpper().Contains("IXIC"))
                    {
                        index.Type = MajorIndexType.Nasdaq;
                    }
                    else
                    {
                        index.Type = MajorIndexType.Unknown;
                    }
                }

                return majorIndices;
            }
        }
    }
}

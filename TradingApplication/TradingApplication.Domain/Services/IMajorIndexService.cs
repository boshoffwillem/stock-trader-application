using System.Collections.Generic;
using System.Threading.Tasks;
using TradingApplication.Domain.Models;

namespace TradingApplication.Domain.Services
{
   public interface IMajorIndexService
   {
      Task<IEnumerable<MajorIndex>> GetMajorIndices();
   }
}

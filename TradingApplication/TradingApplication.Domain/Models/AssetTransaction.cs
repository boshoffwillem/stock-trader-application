using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApplication.Domain.Models
{
    public class AssetTransaction
    {
        public int Id { get; set; }

        public Account Account { get; set; }

        public bool IsPurchased { get; set; }

        public Stock Stock { get; set; }

        public int Shares { get; set; }

        public DateTime DateProcessed { get; set; }
    }
}

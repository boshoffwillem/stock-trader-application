using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApplication.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }

        public User AccountHolder { get; set; }

        public decimal Balance { get; set; }

        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }
    }
}

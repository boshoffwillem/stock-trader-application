using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApplication.Domain.Models
{
    public class Stock
    {
        public string Symbol { get; set; }

        public decimal PricePerShare { get; set; }
    }
}

using System;

namespace TradingApplication.Domain.Models
{
   public class AssetTransaction : DomainObject
   {
      public Account Account { get; set; }

      public bool IsPurchased { get; set; }

      public Stock Stock { get; set; }

      public int Shares { get; set; }

      public DateTime DateProcessed { get; set; }
   }
}

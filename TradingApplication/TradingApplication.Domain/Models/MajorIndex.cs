namespace TradingApplication.Domain.Models
{
   public enum MajorIndexType
   {
      Unknown,
      DowJones,
      Nasdaq,
      SP500
   }

   public class MajorIndex
   {
      public string Symbol { get; set; }

      public string Name { get; set; }

      public decimal Price { get; set; }

      public decimal ChangesPercentage { get; set; }

      public decimal Change { get; set; }

      public MajorIndexType Type { get; set; }
   }
}

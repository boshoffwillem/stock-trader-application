using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TradingApplication.EntityFramework
{
   public class TradingApplicationDbContextFactory : IDesignTimeDbContextFactory<TradingApplicationDbContext>
   {
      public TradingApplicationDbContext CreateDbContext(string[] args = null)
      {
         var options = new DbContextOptionsBuilder<TradingApplicationDbContext>();
         options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TradingApplication;Trusted_Connection=True;");
         return new TradingApplicationDbContext(options.Options);
      }
   }
}

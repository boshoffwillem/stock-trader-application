using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TradingApplication.EntityFramework
{
   public class TradingApplicationDbContextFactory : IDesignTimeDbContextFactory<TradingApplicationDbContext>
   {
      public TradingApplicationDbContext CreateDbContext(string[] args = null)
      {
         var options = new DbContextOptionsBuilder<TradingApplicationDbContext>();
         options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TradingApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
         return new TradingApplicationDbContext(options.Options);
      }
   }
}

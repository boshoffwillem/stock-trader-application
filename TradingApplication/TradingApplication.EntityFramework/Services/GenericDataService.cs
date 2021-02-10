using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;
using TradingApplication.EntityFramework.Services.Common;

namespace TradingApplication.EntityFramework.Services
{
   public class GenericDataService<T> : IDataService<T> where T : DomainObject
   {
      private readonly TradingApplicationDbContextFactory contextFactory;
      private readonly NonQueryDataService<T> nonQueryDataService;

      public GenericDataService(TradingApplicationDbContextFactory contextFactory)
      {
         this.contextFactory = contextFactory;
         nonQueryDataService = new NonQueryDataService<T>(this.contextFactory);
      }

      public async Task<T> Create(T entity)
      {
          return await nonQueryDataService.Create(entity);
      }

      public async Task<bool> Delete(int id)
      {
          return await nonQueryDataService.Delete(id);
      }

      public async Task<T> Get(int id)
      {
         using (var context = contextFactory.CreateDbContext())
         {
            var entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
         }
      }

      public async Task<IEnumerable<T>> GetAll()
      {
         using (var context = contextFactory.CreateDbContext())
         {
            var entities = await context.Set<T>().ToListAsync();
            return entities;
         }
      }

      public async Task<T> Update(int id, T entity)
      {
          return await nonQueryDataService.Update(id, entity);
      }
   }
}

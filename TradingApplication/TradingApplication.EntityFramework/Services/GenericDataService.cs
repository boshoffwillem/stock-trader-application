using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;

namespace TradingApplication.EntityFramework.Services
{
   public class GenericDataService<T> : IDataService<T> where T : DomainObject
   {
      private readonly TradingApplicationDbContextFactory contextFactory;

      public GenericDataService(TradingApplicationDbContextFactory contextFactory)
      {
         this.contextFactory = contextFactory;
      }

      public async Task<T> Create(T entity)
      {
         using (TradingApplicationDbContext context = contextFactory.CreateDbContext())
         {
            var createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
         }
      }

      public async Task<bool> Delete(int id)
      {
         using (TradingApplicationDbContext context = contextFactory.CreateDbContext())
         {
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
         }
      }

      public async Task<T> Get(int id)
      {
         using (TradingApplicationDbContext context = contextFactory.CreateDbContext())
         {
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
         }
      }

      public async Task<IEnumerable<T>> GetAll()
      {
         using (TradingApplicationDbContext context = contextFactory.CreateDbContext())
         {
            IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            return entities;
         }
      }

      public async Task<T> Update(int id, T entity)
      {
         using (TradingApplicationDbContext context = contextFactory.CreateDbContext())
         {
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
         }
      }
   }
}

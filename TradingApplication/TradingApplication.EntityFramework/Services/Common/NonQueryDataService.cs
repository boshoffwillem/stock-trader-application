using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradingApplication.Domain.Models;

namespace TradingApplication.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {

        private readonly TradingApplicationDbContextFactory contextFactory;

        public NonQueryDataService(TradingApplicationDbContextFactory contextFactory)
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

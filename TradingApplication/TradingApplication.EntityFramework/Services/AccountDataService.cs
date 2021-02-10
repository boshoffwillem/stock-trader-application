using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;
using TradingApplication.EntityFramework.Services.Common;

namespace TradingApplication.EntityFramework.Services
{
    public class AccountDataService : IDataService<Account>
    {
        private readonly TradingApplicationDbContextFactory contextFactory;
        private readonly NonQueryDataService<Account> nonQueryDataService;

        public AccountDataService(TradingApplicationDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            nonQueryDataService = new NonQueryDataService<Account>(this.contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var entity = await context.Accounts.Include(a => a.AssetTransactions).FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var entities = await context.Accounts.Include(a => a.AssetTransactions).ToListAsync();
                return entities;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}

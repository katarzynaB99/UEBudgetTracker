using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.EntityFramework.Services
{
    public class AccountDataService : IDataService<Account>
    {
        private readonly BudgetTrackerDbContextFactory _contextFactory;

        public AccountDataService(BudgetTrackerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Account> accounts = await context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<Account> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var account = await context.Accounts.FirstOrDefaultAsync(e => e.Id == id);
            return account;
        }

        public async Task<Account> Create(Account entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            throw new NotImplementedException();
        }

        public async Task<Account> Update(int id, Account entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            throw new NotImplementedException();
        }
    }
}

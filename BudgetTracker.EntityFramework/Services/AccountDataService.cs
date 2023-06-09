using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Exceptions;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly BudgetTrackerDbContextFactory _contextFactory;

        public AccountDataService(BudgetTrackerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Account> GetByAccountNameAndUserId(string accountName, int userId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Accounts
                .FirstOrDefaultAsync(e => e.Name == accountName && e.UserId == userId);
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
            IDataService<User> userService = new GenericDataService<User>(_contextFactory);

            // Check if account already exists
            var accountsWithSameName = await GetByAccountNameAndUserId(entity.Name, entity.UserId);
            if (accountsWithSameName != null)
            {
                throw new AccountNameExistsException(entity.Name);
            }

            var createdResult = await context.Accounts.AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<Account> Update(int id, Account entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Accounts.FirstOrDefaultAsync(e => e.Id == id);
            context.Accounts.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

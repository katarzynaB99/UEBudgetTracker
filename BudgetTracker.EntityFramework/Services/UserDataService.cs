using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.EntityFramework.Services
{
    public class UserDataService : IUserService
    {
        private readonly BudgetTrackerDbContextFactory _contextFactory;

        public UserDataService(BudgetTrackerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            await using var context = _contextFactory.CreateDbContext();
            var entities = await context.Users.ToListAsync();
            return entities;
        }

        public async Task<User> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Users
                .Include(e => e.Accounts)
                .Include(e => e.Bills)
                .Include(e => e.Categories)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> Create(User entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            var createdResult = await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<User> Update(int id, User entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Users.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Users.FirstOrDefaultAsync(e => e.Id == id);
            context.Users.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByUsername(string username)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Users
                .Include(e => e.Accounts)
                .Include(e => e.Categories)
                .Include(e => e.Bills)
                .FirstOrDefaultAsync(e => e.Username == username);
        }
    }
}

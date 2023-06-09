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
    public class CategoryDataService : ICategoryService
    {
        private readonly BudgetTrackerDbContextFactory _contextFactory;

        public CategoryDataService(BudgetTrackerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Category> GetByCategoryNameAndUserId(string categoryName, int userId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Categories
                .FirstOrDefaultAsync(e => e.Name == categoryName && e.UserId == userId);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Category> categories = await context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var category = await context.Categories.FirstOrDefaultAsync(e => e.Id == id);
            return category;
        }

        public async Task<Category> Create(Category entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            IDataService<User> userService = new GenericDataService<User>(_contextFactory);

            // Check if account already exists
            var categoryWithTheSameName = await GetByCategoryNameAndUserId(entity.Name, entity.UserId);
            if (categoryWithTheSameName != null)
            {
                throw new CategoryNameExistsException(entity.Name);
            }

            var createdResult = await context.Categories.AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public Task<Category> Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Categories.FirstOrDefaultAsync(e => e.Id == id);
            context.Categories.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

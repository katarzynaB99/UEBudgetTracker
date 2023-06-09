using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.Domain.Services
{
    public interface ICategoryService : IDataService<Category>
    {
        Task<Category> GetByCategoryNameAndUserId(string categoryName, int userId);
    }
}

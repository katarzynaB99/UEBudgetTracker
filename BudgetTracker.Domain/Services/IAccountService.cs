using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByAccountNameAndUserId(string accountName, int userId);
    }
}

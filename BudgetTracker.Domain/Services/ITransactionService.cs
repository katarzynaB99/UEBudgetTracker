using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.Domain.Services
{
    public interface ITransactionService : IDataService<Transaction>
    {
        Task<IEnumerable<Transaction>> GetRecentTransactions(int userId, int numberOfTransactions);
        Task<IEnumerable<Transaction>> GetTransactionsByType(int userId, int transactionTypeId);
        Task<IEnumerable<Transaction>> GetTransactionsByCategory(int userId, int categoryId);
        Task<IEnumerable<Transaction>> GetTransactionsByAccount(int accountId);
        Task<IEnumerable<Transaction>> GetTransactionsByUser(int userId);
    }
}

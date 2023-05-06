using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.WPF.State.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        IEnumerable<Transaction> UserTransactions { get; set; }
        event Action StateChanged;

        Task<Account> CreateAccount(string name, double balance);
        Task<Bill> CreateBill(string name, DateTime dueDate, double amount, bool paid, Category category);
        Task<Category> CreateCategory(string name);

        Task<Transaction> CreateTransaction(string name, double amount, DateTime transactionDate,
            Category category, Account account);

        Task RemoveAccount(Account account);
        Task RemoveCategory(Category category);
        Task RemoveTransaction(Transaction transaction);
        Task FetchUserTransactions();

        /*Account UpdateAccount(Account account);
        Bill UpdateBill*/
    }
}

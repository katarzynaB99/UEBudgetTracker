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
        event Action StateChanged;

        Task<Account> CreateAccount(string name, double balance);
        Task<Bill> CreateBill(string name, DateTime dueDate, double amount, bool paid);
        Task<Category> CreateCategory(string name, TransactionType type);

        Task<Transaction> CreateTransaction(string name, double amount, DateTime transactionDate,
            Category category);

        /*Account UpdateAccount(Account account);
        Bill UpdateBill*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;

namespace BudgetTracker.WPF.State.Users
{
    public class UserStore : IUserStore
    {
        private readonly IUserService _userDataService;
        private readonly IDataService<Account> _accountDataService;
        private readonly IBillService _billDataService;
        private readonly ITransactionService _transactionService;
        private readonly IDataService<Category> _categoryDataService;

        private User _currentUser;
        private IEnumerable<Transaction> _userTransactions;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }

        public IEnumerable<Transaction> UserTransactions
        {
            get => _userTransactions;
            set
            {
                _userTransactions = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
        public async Task<Account> CreateAccount(string name, double balance)
        {
            var newAccount = new Account
            {
                Name = name,
                Balance = balance,
                CreationDate = DateTime.Now,
                UserId = CurrentUser.Id
            };

            var accounts = CurrentUser.Accounts.ToList();
            accounts.Add(newAccount);
            CurrentUser.Accounts = accounts;
            StateChanged?.Invoke();
            return await _accountDataService.Create(newAccount);
        }

        public async Task<Bill> CreateBill(string name, DateTime dueDate, double amount, bool paid, Category category)
        {
            var newBill = new Bill
            {
                Amount = amount,
                Name = name,
                DueDate = dueDate,
                Paid = paid,
                CategoryId = category.Id,
                UserId = CurrentUser.Id,
                CreationDate = DateTime.Now
            };

            var bills = CurrentUser.Bills.ToList();
            bills.Add(newBill);
            CurrentUser.Bills = bills;
            StateChanged?.Invoke();
            return await _billDataService.Create(newBill);
        }

        public async Task<Category> CreateCategory(string name)
        {
            var newCategory = new Category
            {
                Name = name,
                UserId = CurrentUser.Id,
                CreationDate = DateTime.Now
            };
            var categories = CurrentUser.Categories.ToList();
            categories.Add(newCategory);
            CurrentUser.Categories = categories;
            StateChanged?.Invoke();
            return await _categoryDataService.Create(newCategory);
        }

        public async Task<Transaction> CreateTransaction(string name, double amount, DateTime transactionDate,
            Category category, Account account)
        {
            var newTransaction = new Transaction
            {
                Name = name,
                TransactionDate = transactionDate,
                Amount = amount,
                AccountId = account.Id,
                CategoryId = category.Id,
            };
            var transactions = UserTransactions.ToList();
            transactions.Add(newTransaction);
            UserTransactions = transactions;
            StateChanged?.Invoke();
            return await _transactionService.Create(newTransaction);
        }

        public async Task RemoveAccount(Account account)
        {
            var accounts = CurrentUser.Accounts.ToList();
            accounts.Remove(account);
            CurrentUser.Accounts = accounts;
            StateChanged?.Invoke();
            await _accountDataService.Delete(account.Id);
        }

        public async Task RemoveCategory(Category category)
        {
            var categories = CurrentUser.Categories.ToList();
            categories.Remove(category);
            CurrentUser.Categories = categories;
            StateChanged?.Invoke();
            await _categoryDataService.Delete(category.Id);
        }

        public async Task FetchUserTransactions()
        {
            if (CurrentUser != null)
            {
                UserTransactions = await _transactionService.GetTransactionsByUser(CurrentUser.Id);
                StateChanged?.Invoke();
            }
        }

        public UserStore(IUserService userDataService,
            IDataService<Account> accountDataService,
            IBillService billDataService,
            ITransactionService transactionService,
            IDataService<Category> categoryDataService)
        {
            _userDataService = userDataService;
            _accountDataService = accountDataService;
            _billDataService = billDataService;
            _transactionService = transactionService;
            _categoryDataService = categoryDataService;
        }
    }
}

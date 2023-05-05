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
        private readonly IDataService<TransactionType> _transactionTypeDataService;
        private readonly ITransactionService _transactionService;

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
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

        public async Task<Bill> CreateBill(string name, DateTime dueDate, double amount, bool paid)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> CreateCategory(string name, TransactionType type)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> CreateTransaction(string name, double amount, DateTime transactionDate,
            Category category)
        {
            throw new NotImplementedException();
        }

        public UserStore(IUserService userDataService,
            IDataService<Account> accountDataService,
            IBillService billDataService,
            IDataService<TransactionType> transactionTypeDataService,
            ITransactionService transactionService)
        {
            _userDataService = userDataService;
            _accountDataService = accountDataService;
            _billDataService = billDataService;
            _transactionTypeDataService = transactionTypeDataService;
            _transactionService = transactionService;
        }
    }
}

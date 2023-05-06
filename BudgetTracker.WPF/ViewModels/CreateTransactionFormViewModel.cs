using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands.Create;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class CreateTransactionFormViewModel : ViewModelBase
    {
        private readonly IUserStore _userStore;

        // Transaction properties
        private string _name;
        private double _amount;
        private DateTime _transactionDate;
        private Account _account;
        private Category _category;

        // UI messages
        private string _nameErrorMessage;
        private string _amountErrorMessage;
        private string _transactionDateErrorMessage;
        private string _accountErrorMessage;
        private string _categoryErrorMessage;
        private string _errorMessage;

        private IEnumerable<Account> _userAccounts;
        private IEnumerable<Category> _userCategories;

        public IEnumerable<Account> UserAccounts
        {
            get => _userAccounts;
            set
            {
                _userAccounts = value;
                OnPropertyChanged(nameof(UserAccounts));
            }
        }

        public IEnumerable<Category> UserCategories
        {
            get => _userCategories;
            set
            {
                _userCategories = value;
                OnPropertyChanged(nameof(UserCategories));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NameErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                AmountErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public DateTime TransactionDate
        {
            get => _transactionDate;
            set
            {
                _transactionDate = value;
                TransactionDateErrorMessage = string.Empty;
                OnPropertyChanged(nameof(TransactionDate));
            }
        }

        public Account Account
        {
            get => _account;
            set
            {
                _account = value;
                AccountErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Account));
            }
        }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                CategoryErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set
            {
                _nameErrorMessage = value;
                OnPropertyChanged(nameof(NameErrorMessage));
            }
        }

        public string AmountErrorMessage
        {
            get => _amountErrorMessage;
            set
            {
                _amountErrorMessage = value;
                OnPropertyChanged(nameof(AmountErrorMessage));
            }
        }

        public string TransactionDateErrorMessage
        {
            get => _transactionDateErrorMessage;
            set
            {
                _transactionDateErrorMessage = value;
                OnPropertyChanged(nameof(TransactionDateErrorMessage));
            }
        }

        public string AccountErrorMessage
        {
            get => _accountErrorMessage;
            set
            {
                _accountErrorMessage = value;
                OnPropertyChanged(nameof(AccountErrorMessage));
            }
        }

        public string CategoryErrorMessage
        {
            get => _categoryErrorMessage;
            set
            {
                _categoryErrorMessage = value;
                OnPropertyChanged(nameof(CategoryErrorMessage));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool CanSubmit => string.IsNullOrEmpty(NameErrorMessage) &&
                                 string.IsNullOrEmpty(AmountErrorMessage) &&
                                 string.IsNullOrEmpty(TransactionDateErrorMessage) &&
                                 string.IsNullOrEmpty(AccountErrorMessage) &&
                                 string.IsNullOrEmpty(CategoryErrorMessage);

        public ICommand SubmitCommand { get; }

        public CreateTransactionFormViewModel(IRenavigator renavigator, IUserStore userStore)
        {
            _userStore = userStore;
            NameErrorMessage = string.Empty;
            AmountErrorMessage = string.Empty;
            TransactionDateErrorMessage = string.Empty;
            AccountErrorMessage = string.Empty;
            CategoryErrorMessage = string.Empty;

            UserAccounts = _userStore.CurrentUser?.Accounts;
            UserCategories = _userStore.CurrentUser?.Categories;

            SubmitCommand = new CreateTransactionCommand(this, renavigator, _userStore);
        }
    }
}

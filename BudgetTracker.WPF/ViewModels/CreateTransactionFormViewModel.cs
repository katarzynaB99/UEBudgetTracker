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
        private string _amountField;
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
                if (string.IsNullOrEmpty(value))
                {
                    NameErrorMessage = "This field is required.";
                }
                else
                {
                    NameErrorMessage = string.Empty;
                }
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanSubmit));
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
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string AmountField
        {
            get => _amountField;
            set
            {
                _amountField = value;
                ErrorMessage = string.Empty;

                OnPropertyChanged(nameof(AmountField));

                if (string.IsNullOrEmpty(value))
                {
                    AmountErrorMessage = "This field is required.";
                }
                else if (!double.TryParse(value, out _))
                {
                    AmountErrorMessage = "Value must be a valid number.";
                }
                else
                {
                    AmountErrorMessage = string.Empty;
                    Amount = double.Parse(value);
                }
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public DateTime TransactionDate
        {
            get => _transactionDate;
            set
            {
                _transactionDate = value;
                if (value == null)
                {
                    TransactionDateErrorMessage = "This field is required";
                }
                else
                {
                    TransactionDateErrorMessage = string.Empty;
                }
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(TransactionDate));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public Account Account
        {
            get => _account;
            set
            {
                _account = value;
                if (value == null)
                {
                    AccountErrorMessage = "This field is required";
                }
                else
                {
                    AccountErrorMessage = string.Empty;
                }
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Account));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;

                if (value == null)
                {
                    CategoryErrorMessage = "This field is required";
                }
                else
                {
                    CategoryErrorMessage = string.Empty;
                }

                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Category));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set
            {
                _nameErrorMessage = value;
                OnPropertyChanged(nameof(NameErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string AmountErrorMessage
        {
            get => _amountErrorMessage;
            set
            {
                _amountErrorMessage = value;
                OnPropertyChanged(nameof(AmountErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string TransactionDateErrorMessage
        {
            get => _transactionDateErrorMessage;
            set
            {
                _transactionDateErrorMessage = value;
                OnPropertyChanged(nameof(TransactionDateErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string AccountErrorMessage
        {
            get => _accountErrorMessage;
            set
            {
                _accountErrorMessage = value;
                OnPropertyChanged(nameof(AccountErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string CategoryErrorMessage
        {
            get => _categoryErrorMessage;
            set
            {
                _categoryErrorMessage = value;
                OnPropertyChanged(nameof(CategoryErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
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

            TransactionDate = DateTime.Now;

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

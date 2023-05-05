using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using BudgetTracker.EntityFramework.Services;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class TransactionsViewModel : ViewModelBase
    {
        private readonly IUserStore _userStore;
        private readonly ITransactionService _transactionService;
        private ObservableCollection<Transaction> _transactions;

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged(nameof(Transactions));
            }
        }

        public ICommand ViewCreateTransactionFormCommand { get; }

        public TransactionsViewModel(IUserStore userStore, ITransactionService transactionService, IRenavigator createTransactionRenavigator)
        {
            _userStore = userStore;
            _transactionService = transactionService;
            ViewCreateTransactionFormCommand = new RenavigateCommand(createTransactionRenavigator);
            Transactions = new ObservableCollection<Transaction>(_userStore.UserTransactions);
        }
    }
}

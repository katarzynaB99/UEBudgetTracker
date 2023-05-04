using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using BudgetTracker.EntityFramework.Services;
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

        public TransactionsViewModel(IUserStore userStore, ITransactionService transactionService)
        {
            _userStore = userStore;
            _transactionService = transactionService;
            Transactions = new ObservableCollection<Transaction>(_transactionService
                .GetTransactionsByUser(_userStore.CurrentUser.Id)
                .GetAwaiter()
                .GetResult());
        }
    }
}

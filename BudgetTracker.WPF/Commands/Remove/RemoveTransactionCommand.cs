using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Remove
{
    public class RemoveTransactionCommand : AsyncCommandBase
    {
        private readonly TransactionsViewModel _transactionsViewModel;
        private readonly IUserStore _userStore;

        public RemoveTransactionCommand(TransactionsViewModel transactionsViewModel,
            IUserStore userStore)
        {
            _transactionsViewModel = transactionsViewModel;
            _userStore = userStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var transaction = (Transaction) parameter;
            await _userStore.RemoveTransaction(transaction);
            _transactionsViewModel.Transactions.Remove(transaction);
        }
    }
}

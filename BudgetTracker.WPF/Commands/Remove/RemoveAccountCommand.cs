using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Remove
{
    public class RemoveAccountCommand : AsyncCommandBase
    {
        private readonly AccountsViewModel _accountsViewModel;
        private readonly IUserStore _userStore;

        public RemoveAccountCommand(AccountsViewModel accountsViewModel, IUserStore userStore)
        {
            _accountsViewModel = accountsViewModel;
            _userStore = userStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = (Account)parameter;
            await _userStore.RemoveAccount(account);
            _accountsViewModel.Accounts.Remove(account);
        }
    }
}

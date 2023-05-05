using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.Commands.Remove
{
    public class RemoveAccountCommand : AsyncCommandBase
    {
        private readonly IUserStore _userStore;

        public RemoveAccountCommand(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = (Account)parameter;
            await _userStore.RemoveAccount(account);
        }
    }
}

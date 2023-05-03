using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class AccountsViewModelFactory : IBudgetTrackerViewModelFactory<AccountsViewModel>
    {
        public AccountsViewModel CreateViewModel()
        {
            return new AccountsViewModel();
        }
    }
}

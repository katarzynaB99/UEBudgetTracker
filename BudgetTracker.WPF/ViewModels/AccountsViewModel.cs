using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Assets;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class AccountsViewModel : ViewModelBase
    {
        private readonly IUserStore _userStore;
        private ObservableCollection<Account> _accounts;

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }
        public AccountsViewModel(IUserStore userStore)
        {
            _userStore = userStore;
            // Initialize the Accounts collection with the user's accounts
            Accounts = new ObservableCollection<Account>(_userStore.CurrentUser.Accounts);
        }
    }
}

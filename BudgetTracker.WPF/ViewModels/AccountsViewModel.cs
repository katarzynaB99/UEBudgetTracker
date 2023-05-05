using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Assets;
using BudgetTracker.WPF.State.Navigators;
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

        public ICommand ViewCreateAccountFormCommand { get; }

        public AccountsViewModel(IUserStore userStore, IRenavigator createAccountRenavigator)
        {
            _userStore = userStore;
            ViewCreateAccountFormCommand = new RenavigateCommand(createAccountRenavigator);
            // Initialize the Accounts collection with the user's accounts
            Accounts = new ObservableCollection<Account>(_userStore.CurrentUser.Accounts);
        }
    }
}

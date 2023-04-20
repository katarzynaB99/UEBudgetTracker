using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTrackerWpf.Commands;
using BudgetTrackerWpf.Stores;

namespace BudgetTrackerWpf.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand NavigateRegisterCommand { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
        }
    }
}

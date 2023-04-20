using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTrackerWpf.Commands;
using BudgetTrackerWpf.Stores;

namespace BudgetTrackerWpf.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        public ICommand NavigateLoginCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}

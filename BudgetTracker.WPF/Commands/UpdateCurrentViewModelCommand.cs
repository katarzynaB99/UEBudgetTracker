using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = viewType switch
                {
                    ViewType.Accounts => new AccountsViewModel(),
                    ViewType.Analytics => new AnalyticsViewModel(),
                    ViewType.Bills => new BillsViewModel(),
                    ViewType.Categories => new CategoriesViewModel(),
                    ViewType.Dashboard => new DashboardViewModel(),
                    ViewType.SignIn => new SignInViewModel(),
                    ViewType.SignUp => new SignUpViewModel(),
                    ViewType.Transactions => new TransactionsViewModel(),
                    _ => throw new NotSupportedException("This type of view model does not exist"),
                };
            }
        }
    }
}

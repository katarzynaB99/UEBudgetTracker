using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;
using BudgetTrackerWpf.ViewModels;

namespace BudgetTrackerWpf.Commands
{
    class NavigateCommand<T> : CommandBase
        where T : ViewModelBase
    {
        private readonly NavigationService<T> _navigationService;

        public NavigateCommand(NavigationService<T> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}

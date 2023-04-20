using System;
using System.Collections.Generic;
using System.Text;
using BudgetTrackerWpf.Stores;
using BudgetTrackerWpf.ViewModels;

namespace BudgetTrackerWpf.Commands
{
    class NavigateCommand<T> : CommandBase
        where T : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<T> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<T> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

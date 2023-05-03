using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;
using BudgetTracker.WPF.ViewModels.Factories;

namespace BudgetTracker.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IBudgetTrackerViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IBudgetTrackerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}

using BudgetTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.Models;
using BudgetTracker.WPF.ViewModels.Factories;

namespace BudgetTracker.WPF.State.Navigators
{
    class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}

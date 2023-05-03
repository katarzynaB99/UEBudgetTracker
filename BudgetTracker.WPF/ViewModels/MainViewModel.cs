using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels.Factories;

namespace BudgetTracker.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBudgetTrackerViewModelFactory _viewModelFactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get;  }
        public ICommand UpdateCurrentViewModelCommand { get; }


        public MainViewModel(INavigator navigator, IBudgetTrackerViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;
            Authenticator = authenticator;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.SignIn);
        }
    }
}

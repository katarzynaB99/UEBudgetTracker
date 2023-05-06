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
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;


        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand SignOutCommand { get; }
        public ICommand ImportUserDataCommand { get; }
        public ICommand ExportUserDataCommand { get; }


        public MainViewModel(INavigator navigator, IBudgetTrackerViewModelFactory viewModelFactory,
            IAuthenticator authenticator,
            ViewModelFactoryRenavigator<SignInViewModel> signInViewRenavigator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            SignOutCommand = new SignOutCommand(authenticator, signInViewRenavigator);
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.SignIn);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
}

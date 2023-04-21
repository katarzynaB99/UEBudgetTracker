using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTrackerWpf.Commands;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;

namespace BudgetTrackerWpf.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                ErrorMessage = null;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ErrorMessage = null;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand NavigateRegisterCommand { get; }
        public ICommand LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(
                new NavigationService<RegisterViewModel>(navigationStore,
                    () => new RegisterViewModel(navigationStore, userStore)));
            LoginCommand = new LoginCommand(this, userStore,
                new NavigationService<DashboardViewModel>(navigationStore,
                    () => new DashboardViewModel(navigationStore, userStore)));
        }
    }
}

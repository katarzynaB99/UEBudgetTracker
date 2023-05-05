using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSignUp));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanSignUp));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanSignUp));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(ErrorMessage);
                OnPropertyChanged(nameof(CanSignUp));
            }
        }

        public bool CanSignUp => !string.IsNullOrEmpty(Username) &&
                                 !string.IsNullOrEmpty(Password) &&
                                 !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand SignUpCommand { get; }
        public ICommand ViewSignInCommand { get; }

        public SignUpViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator,
            IRenavigator registerRenavigator)
        {
            SignUpCommand = new SignUpCommand(this, authenticator, registerRenavigator);
            ViewSignInCommand = new RenavigateCommand(loginRenavigator);

            Username = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}

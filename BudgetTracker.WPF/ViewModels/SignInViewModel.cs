using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels
{
    public class SignInViewModel : ViewModelBase
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
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSignIn));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanSignIn));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(ErrorMessage);
                OnPropertyChanged(nameof(CanSignIn));
            } }

        public bool CanSignIn => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);


        public ICommand SignInCommand { get; }
        public ICommand ViewRegisterCommand { get; }

        public SignInViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
        {
            SignInCommand = new SignInCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}

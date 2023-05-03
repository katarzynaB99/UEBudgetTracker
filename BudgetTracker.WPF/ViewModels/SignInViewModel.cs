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

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand SignInCommand { get; }

        public SignInViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            SignInCommand = new SignInCommand(this, authenticator, renavigator);
        }
    }
}

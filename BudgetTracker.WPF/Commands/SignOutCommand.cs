using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.State.Authenticators;

namespace BudgetTracker.WPF.Commands
{
    public class SignOutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;

        public SignOutCommand(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _authenticator.SignOut();
        }

        public event EventHandler CanExecuteChanged;
    }
}

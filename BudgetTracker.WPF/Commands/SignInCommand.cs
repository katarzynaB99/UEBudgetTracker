using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands
{
    public class SignInCommand : ICommand
    {
        private readonly SignInViewModel _signInViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public SignInCommand(SignInViewModel signInViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _signInViewModel = signInViewModel;
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var success = await _authenticator.Login(_signInViewModel.Username, parameter.ToString());
            if (success)
            {
                _renavigator.Renavigate();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}

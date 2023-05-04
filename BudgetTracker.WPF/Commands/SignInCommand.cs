using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;
using BudgetTracker.Domain.Exceptions;

namespace BudgetTracker.WPF.Commands
{
    public class SignInCommand : AsyncCommandBase
    {
        private readonly SignInViewModel _signInViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public SignInCommand(SignInViewModel signInViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _signInViewModel = signInViewModel;
            _renavigator = renavigator;

            _signInViewModel.PropertyChanged += SignInViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) => _signInViewModel.CanSignIn;

        public override async Task ExecuteAsync(object parameter)
        {
            _signInViewModel.ErrorMessage = string.Empty;
            try
            {
                await _authenticator.Login(_signInViewModel.Username, _signInViewModel.Password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                _signInViewModel.ErrorMessage = "Invalid username and/or password";
            }
            catch (InvalidPasswordException)
            {
                _signInViewModel.ErrorMessage = "Invalid username and/or password";
            }
            catch (Exception)
            {
                _signInViewModel.ErrorMessage = "Sign in failed.";
            }
        }

        private void SignInViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SignInViewModel.CanSignIn))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Exceptions;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands
{
    class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpViewModel _signUpViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public SignUpCommand(SignUpViewModel signUpViewModel, IAuthenticator authenticator,
            IRenavigator renavigator)
        {
            _signUpViewModel = signUpViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _signUpViewModel.PropertyChanged += SignUpViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) => _signUpViewModel.CanSignUp;

        public override async Task ExecuteAsync(object parameter)
        {
            _signUpViewModel.ErrorMessage = string.Empty;
            try
            {
                await _authenticator.Register(_signUpViewModel.Username,
                    _signUpViewModel.Password,
                    _signUpViewModel.ConfirmPassword);
                _renavigator.Renavigate();
            }
            catch (UserExistsException)
            {
                _signUpViewModel.ErrorMessage =
                    "Username '" + _signUpViewModel.Username + "' is already taken.";
            }
            catch (PasswordsDontMatchException)
            {
                _signUpViewModel.ErrorMessage = "Passwords don't match.";
            }
            catch (Exception)
            {
                _signUpViewModel.ErrorMessage = "Sign up failed.";
            }
        }

        private void SignUpViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SignUpViewModel.CanSignUp))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

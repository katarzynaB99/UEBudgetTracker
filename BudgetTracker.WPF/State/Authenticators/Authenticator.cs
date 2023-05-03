using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services.AuthenticationServices;
using BudgetTracker.WPF.Models;

namespace BudgetTracker.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(username, password, confirmPassword);
        }

        public async Task<bool> Login(string username, string password)
        {
            var success = true;
            try
            {
                CurrentUser = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public void SignOut()
        {
            CurrentUser = null;
        }
    }
}

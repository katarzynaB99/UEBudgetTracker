using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services.AuthenticationServices;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _userStore;

        public Authenticator(IAuthenticationService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }

        public User CurrentUser
        {
            get => _userStore.CurrentUser;
            private set
            {
                _userStore.CurrentUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(username, password, confirmPassword);
        }

        public async Task Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);
            if (CurrentUser != null)
            {
                await _userStore.FetchUserTransactions();
            }
        }

        public void SignOut()
        {
            CurrentUser = null;
        }
    }
}

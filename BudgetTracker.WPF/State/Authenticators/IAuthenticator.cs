using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services.AuthenticationServices;

namespace BudgetTracker.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string username, string password, string confirmPassword);
        Task Login(string username, string password);
        void SignOut();
        event Action StateChanged;
    }
}

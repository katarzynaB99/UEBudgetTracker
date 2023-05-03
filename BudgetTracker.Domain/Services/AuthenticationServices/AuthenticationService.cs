using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BudgetTracker.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> Register(string username, string password, string confirmPassword)
        {
            var success = false;

            if (password == confirmPassword)
            {
                var hasher = new PasswordHasher<User>();
                var user = new User
                {
                    Username = username
                };
                user.Password = hasher.HashPassword(user, password);
            }

            return success;
        }

        public async Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}

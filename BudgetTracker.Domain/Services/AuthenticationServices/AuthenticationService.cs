using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BudgetTracker.Domain.Exceptions;
using BudgetTracker.Domain.Models;
using Microsoft.AspNet.Identity;

namespace BudgetTracker.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            var result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                throw new PasswordsDontMatchException(password, confirmPassword);
            }

            var usernameUser = await _userService.GetByUsername(username);

            if (usernameUser != null)
            {
                throw new UserExistsException(username);
            }

            if (result == RegistrationResult.Success)
            {
                var hashedPassword = _passwordHasher.HashPassword(password);

                var user = new User
                {
                    Username = username,
                    Password = hashedPassword,
                    CreationDate = DateTime.Now
                };

                await _userService.Create(user);
            }

            return result;
        }

        public async Task<User> Login(string username, string password)
        {
            var storedUser = await _userService.GetByUsername(username);

            if (storedUser == null) throw new UserNotFoundException(username, password);
            var passwordsMatch =
                _passwordHasher.VerifyHashedPassword(storedUser.Password, password);

            if (passwordsMatch != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedUser;
        }
    }
}

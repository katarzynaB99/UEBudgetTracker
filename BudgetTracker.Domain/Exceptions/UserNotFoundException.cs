using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserNotFoundException(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public UserNotFoundException(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }

        public UserNotFoundException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }
}

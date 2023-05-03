using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public InvalidPasswordException(string username, string password)
        {
        }

        public InvalidPasswordException(string message, string username, string password) :
            base(message)
        {
        }

        public InvalidPasswordException(string message, Exception innerException, string username,
            string password) : base(message,
            innerException)
        {
        }
    }
}

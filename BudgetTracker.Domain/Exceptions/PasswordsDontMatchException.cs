using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class PasswordsDontMatchException : Exception
    {
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        public PasswordsDontMatchException(string password, string repeatPassword)
        {
        }

        public PasswordsDontMatchException(string message, string password, string repeatPassword) :
            base(message)
        {
        }

        public PasswordsDontMatchException(string message, Exception innerException,
            string password, string repeatPassword) : base(message, innerException)
        {
        }
    }
}

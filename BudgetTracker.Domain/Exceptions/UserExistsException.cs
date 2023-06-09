using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class UserExistsException : Exception
    {
        public string Username { get; set; }

        public UserExistsException(string username)
        {
        }

        public UserExistsException(string message, string username) : base(message)
        {
        }

        public UserExistsException(string message, Exception innerException, string username) :
            base(message, innerException)
        {
        }
    }
}

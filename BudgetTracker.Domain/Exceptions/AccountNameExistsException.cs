using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class AccountNameExistsException : Exception
    {
        public string AccountName { get; set; }

        public AccountNameExistsException(string accountName)
        {
        }

        public AccountNameExistsException(string message, string accountName) : base(message)
        {
        }

        public AccountNameExistsException(string message, Exception innerException,
            string accountName) : base(message, innerException)
        {
        }
    }
}

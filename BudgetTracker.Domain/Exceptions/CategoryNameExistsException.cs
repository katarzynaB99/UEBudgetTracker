using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Exceptions
{
    public class CategoryNameExistsException : Exception
    {
        public string CategoryName { get; set; }

        public CategoryNameExistsException(string categoryName)
        {
        }

        public CategoryNameExistsException(string message, string categoryName) : base(message)
        {
        }

        public CategoryNameExistsException(string message, Exception innerException,
            string categoryName) : base(message, innerException)
        {
        }
    }
}

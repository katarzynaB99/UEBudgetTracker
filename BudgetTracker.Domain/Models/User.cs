using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
    }
}

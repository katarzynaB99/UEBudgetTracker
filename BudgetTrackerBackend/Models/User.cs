using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BudgetTrackerBackend.Models
{
    public class User
    {
        public User()
        {
            Category = new HashSet<Category>();
            Account = new HashSet<Account>();
            Bill = new HashSet<Bill>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}

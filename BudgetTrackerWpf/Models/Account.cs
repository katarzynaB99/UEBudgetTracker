using System;
using System.Collections.Generic;

namespace BudgetTrackerWpf.Models
{
    public class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public double StartingAmount { get; set; }
        public long UserId { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual User User { get; set; }
    }
}

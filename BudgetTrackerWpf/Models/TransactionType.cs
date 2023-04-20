using System;
using System.Collections.Generic;

namespace BudgetTrackerWpf.Models
{
    public class TransactionType
    {
        public TransactionType()
        {
            Category = new HashSet<Category>();
            Transaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

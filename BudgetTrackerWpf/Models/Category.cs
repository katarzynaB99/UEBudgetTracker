using System;
using System.Collections.Generic;

namespace BudgetTrackerWpf.Models
{
    public class Category
    {
        public Category()
        {
            Bill = new HashSet<Bill>();
            Transaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public long? UserId { get; set; }

        public virtual TransactionType Type { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual User User { get; set; }
    }
}

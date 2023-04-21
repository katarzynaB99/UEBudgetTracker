using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BudgetTrackerBackend.Models
{
    public partial class TransactionType
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

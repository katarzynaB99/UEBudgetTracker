using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BudgetTrackerBackend.Models
{
    public partial class Category
    {
        public Category()
        {
            Bill = new HashSet<Bill>();
            Transaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }

        public virtual TransactionType Type { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

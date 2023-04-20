using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BudgetTrackerBackend.Models
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public long? CategoryId { get; set; }
        public long? TypeId { get; set; }
        public long? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual TransactionType Type { get; set; }
    }
}

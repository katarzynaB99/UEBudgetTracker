using System;
using System.Collections.Generic;

namespace BudgetTrackerWpf.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public long? TypeId { get; set; }
        public long? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual TransactionType Type { get; set; }
    }
}

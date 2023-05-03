using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class Category : DomainObject
    {
        public string Name { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
    }
}

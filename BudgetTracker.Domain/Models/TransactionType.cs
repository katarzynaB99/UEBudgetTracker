using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class TransactionType : DomainObject
    {
        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class Account : DomainObject
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}

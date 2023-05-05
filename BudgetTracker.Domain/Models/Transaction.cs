using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class Transaction : DomainObject
    {
        public string Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int TransactionTypeId { get; set; }
        public Category Category { get; set; }
        public TransactionType TransactionType { get; set; }
        public Account Account { get; set; }
    }
}

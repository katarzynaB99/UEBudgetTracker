using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Domain.Models
{
    public class Bill : DomainObject
    {
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Paid { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}

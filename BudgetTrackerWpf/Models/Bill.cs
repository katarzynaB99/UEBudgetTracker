using System;
using System.Collections.Generic;

namespace BudgetTrackerWpf.Models
{
    public class Bill
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public string DueDate { get; set; }
        public long Paid { get; set; }
        public long? CategoryId { get; set; }
        public long UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}

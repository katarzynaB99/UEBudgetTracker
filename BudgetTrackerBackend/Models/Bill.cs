using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BudgetTrackerBackend.Models
{
    public partial class Bill
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public long Paid { get; set; }
        public long? CategoryId { get; set; }
        public long UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}

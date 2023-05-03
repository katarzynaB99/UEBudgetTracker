using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.WPF.State.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        event Action StateChanged;
    }
}

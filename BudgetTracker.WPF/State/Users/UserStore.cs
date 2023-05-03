using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.WPF.State.Users
{
    public class UserStore : IUserStore
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}

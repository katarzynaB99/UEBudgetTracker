using System;
using System.Collections.Generic;
using System.Text;
using BudgetTrackerWpf.Models;

namespace BudgetTrackerWpf.Stores
{
    public class UserStore
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action CurrentUserChanged;

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}

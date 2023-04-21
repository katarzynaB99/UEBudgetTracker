using System;
using System.Collections.Generic;
using System.Text;
using BudgetTrackerWpf.Models;

namespace BudgetTrackerWpf.Stores
{
    public class UserStore
    {
        private User _currentUser;
        private string _jwtToken;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            }
        }

        public string JwtToken
        {
            get => _jwtToken;
            set
            {
                _jwtToken = value;
                JwtTokenChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null && JwtToken != null;

        public event Action CurrentUserChanged;

        public event Action JwtTokenChanged;

        public void Logout()
        {
            CurrentUser = null;
            JwtToken = null;
        }
    }
}

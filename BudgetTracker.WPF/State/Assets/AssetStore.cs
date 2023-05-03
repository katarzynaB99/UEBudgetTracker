using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.State.Assets
{
    public class AssetStore
    {
        private readonly IUserStore _userStore;

        public IEnumerable<Account> Accounts =>
            _userStore.CurrentUser?.Accounts ?? new List<Account>();

        public IEnumerable<Bill> Bills => _userStore.CurrentUser?.Bills ?? new List<Bill>();

        public IEnumerable<Category> Categories =>
            _userStore.CurrentUser?.Categories ?? new List<Category>();

        public event Action StateChanged;

        public AssetStore(IUserStore userStore)
        {
            _userStore = userStore;
            _userStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class BillsViewModel : ViewModelBase
    {
        private readonly IUserStore _userStore;
        private ObservableCollection<Bill> _bills;

        public ObservableCollection<Bill> Bills
        {
            get => _bills;
            set
            {
                _bills = value;
                OnPropertyChanged(nameof(Bills));
            }
        }

        public BillsViewModel(IUserStore userStore)
        {
            _userStore = userStore;
            Bills = new ObservableCollection<Bill>(_userStore.CurrentUser.Bills);
        }
    }
}

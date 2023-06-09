using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.State.Navigators;
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

        public bool BillsEmpty => Bills.Count == 0;

        public ICommand ViewCreateBillFormCommand { get; }

        public BillsViewModel(IUserStore userStore, IRenavigator createBillRenavigator)
        {
            _userStore = userStore;
            ViewCreateBillFormCommand = new RenavigateCommand(createBillRenavigator);
            Bills = new ObservableCollection<Bill>(_userStore.CurrentUser.Bills);
        }
    }
}

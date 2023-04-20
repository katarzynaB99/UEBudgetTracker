using System;
using System.Collections.Generic;
using System.Text;
using BudgetTrackerWpf.ViewModels;

namespace BudgetTrackerWpf.Stores
{
    public class NavigationStore
    {
        public event Action CurrenViewModelChanged;

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrenViewModelChanged?.Invoke();
        }
    }
}

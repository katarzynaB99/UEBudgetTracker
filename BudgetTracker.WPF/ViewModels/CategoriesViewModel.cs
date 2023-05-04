using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private readonly IUserStore _userStore;
        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public CategoriesViewModel(IUserStore userStore)
        {
            _userStore = userStore;
            Categories = new ObservableCollection<Category>(_userStore.CurrentUser.Categories);
        }
    }
}

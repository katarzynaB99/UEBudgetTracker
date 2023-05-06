using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands;
using BudgetTracker.WPF.Commands.Remove;
using BudgetTracker.WPF.State.Navigators;
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

        public ICommand ViewCreateCategoryFormCommand { get; }
        public ICommand RemoveCategoryCommand { get; }

        public CategoriesViewModel(IUserStore userStore, IRenavigator createCategoryRenavigator)
        {
            _userStore = userStore;
            ViewCreateCategoryFormCommand = new RenavigateCommand(createCategoryRenavigator);
            RemoveCategoryCommand = new RemoveCategoryCommand(this, userStore);
            Categories = new ObservableCollection<Category>(_userStore.CurrentUser.Categories);
        }
    }
}

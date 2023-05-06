using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Remove
{
    public class RemoveCategoryCommand : AsyncCommandBase
    {
        public readonly CategoriesViewModel _categoriesViewModel;
        public readonly IUserStore _userStore;

        public RemoveCategoryCommand(CategoriesViewModel categoriesViewModel, IUserStore userStore)
        {
            _categoriesViewModel = categoriesViewModel;
            _userStore = userStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var category = (Category) parameter;
            await _userStore.RemoveCategory(category);
            _categoriesViewModel.Categories.Remove(category);
        }
    }
}

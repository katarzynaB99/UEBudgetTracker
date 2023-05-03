using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class CategoriesViewModelFactory : IBudgetTrackerViewModelFactory<CategoriesViewModel>
    {
        public CategoriesViewModel CreateViewModel()
        {
            return new CategoriesViewModel();
        }
    }
}

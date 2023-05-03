using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class DashboardViewModelFactory : IBudgetTrackerViewModelFactory<DashboardViewModel>
    {
        public DashboardViewModel CreateViewModel()
        {
            return new DashboardViewModel();
        }
    }
}

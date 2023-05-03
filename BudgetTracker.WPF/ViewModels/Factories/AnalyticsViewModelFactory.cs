using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class AnalyticsViewModelFactory : IBudgetTrackerViewModelFactory<AnalyticsViewModel>
    {
        public AnalyticsViewModel CreateViewModel()
        {
            return new AnalyticsViewModel();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class BillsViewModelFactory : IBudgetTrackerViewModelFactory<BillsViewModel>
    {
        public BillsViewModel CreateViewModel()
        {
            return new BillsViewModel();
        }
    }
}

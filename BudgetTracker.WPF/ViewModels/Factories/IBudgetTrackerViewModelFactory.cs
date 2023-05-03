using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public interface IBudgetTrackerViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public interface IBudgetTrackerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}

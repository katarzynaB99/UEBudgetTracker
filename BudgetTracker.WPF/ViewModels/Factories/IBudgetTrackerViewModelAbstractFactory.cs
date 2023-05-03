using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public interface IBudgetTrackerViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}

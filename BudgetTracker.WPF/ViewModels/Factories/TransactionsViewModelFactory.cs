using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class TransactionsViewModelFactory : IBudgetTrackerViewModelFactory<TransactionsViewModel>
    {
        public TransactionsViewModel CreateViewModel()
        {
            return new TransactionsViewModel();
        }
    }
}

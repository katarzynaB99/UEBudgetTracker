using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class SignUpViewModelFactory : IBudgetTrackerViewModelFactory<SignUpViewModel>
    {
        public SignUpViewModel CreateViewModel()
        {
            return new SignUpViewModel();
        }
    }
}

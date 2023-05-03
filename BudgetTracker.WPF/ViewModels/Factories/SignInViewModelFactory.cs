using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class SignInViewModelFactory : IBudgetTrackerViewModelFactory<SignInViewModel>
    {
        public SignInViewModel CreateViewModel()
        {
            return new SignInViewModel();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.State.Navigators
{
    public enum ViewType
    {
        Accounts,
        Analytics,
        Bills,
        Categories,
        Dashboard,
        SignIn,
        SignUp,
        Transactions,
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}

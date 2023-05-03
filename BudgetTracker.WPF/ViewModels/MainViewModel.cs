using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Dashboard);
        }
    }
}

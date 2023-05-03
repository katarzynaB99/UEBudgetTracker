using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BudgetTracker.WPF.Models;

namespace BudgetTracker.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : ObservableObject
    {
    }
}

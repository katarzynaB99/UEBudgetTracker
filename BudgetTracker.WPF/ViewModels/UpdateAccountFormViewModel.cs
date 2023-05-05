using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands.Create;
using BudgetTracker.WPF.Commands.Update;

namespace BudgetTracker.WPF.ViewModels
{
    public class UpdateAccountFormViewModel : ViewModelBase
    {
        // Account properties
        private string _name;
        private double _balance;

        // UI messages
        private string _formTitle;
        private string _nameErrorMessage;
        private string _balanceErrorMessage;
        private string _errorMessage;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public string FormTitle
        {
            get => _formTitle;
            set
            {
                _formTitle = value;
                OnPropertyChanged(nameof(FormTitle));
            }
        }

        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set
            {
                _nameErrorMessage = value;
                OnPropertyChanged(nameof(NameErrorMessage));
            }
        }

        public string BalanceErrorMessage
        {
            get => _balanceErrorMessage;
            set
            {
                _balanceErrorMessage = value;
                OnPropertyChanged(nameof(BalanceErrorMessage));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Name) &&
                                 string.IsNullOrEmpty(NameErrorMessage) && 
                                 Balance != null &&
                                 string.IsNullOrEmpty(BalanceErrorMessage);

        public ICommand SubmitCommand { get; }

        public UpdateAccountFormViewModel()
        {
            SubmitCommand = new UpdateAccountCommand();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands.Create;
using BudgetTracker.WPF.Commands.Update;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class CreateAccountFormViewModel : ViewModelBase
    {
        // Account properties
        private string _name;
        private double _balance;

        // UI messages
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
                if (!string.IsNullOrEmpty(value)) return;
                NameErrorMessage = "This field is required.";
                OnPropertyChanged(nameof(NameErrorMessage));
            }
        }

        public double Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
                if (value == null || value.ToString() == "")
                {
                    BalanceErrorMessage = "This field is required.";
                    OnPropertyChanged(nameof(BalanceErrorMessage));
                }
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

        public bool CanSubmit => string.IsNullOrEmpty(NameErrorMessage) && 
                                 string.IsNullOrEmpty(BalanceErrorMessage);

        public ICommand SubmitCommand { get; }

        public CreateAccountFormViewModel(IRenavigator renavigator, IUserStore userStore)
        {
            NameErrorMessage = string.Empty;
            BalanceErrorMessage = string.Empty;
            SubmitCommand = new CreateAccountCommand(this, renavigator, userStore);
        }
    }
}

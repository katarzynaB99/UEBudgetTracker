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
        private string _balanceField;
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
                if (string.IsNullOrEmpty(value))
                {
                    NameErrorMessage = "This field is required.";
                }
                else
                {
                    NameErrorMessage = string.Empty;
                }
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string BalanceField
        {
            get => _balanceField;
            set
            {
                _balanceField = value;

                OnPropertyChanged(nameof(BalanceField));
                if (string.IsNullOrEmpty(value))
                {
                    BalanceErrorMessage = "This field is required.";
                } else if (!double.TryParse(value, out _))
                {
                    BalanceErrorMessage = "Value must be a valid number.";
                }
                else
                {
                    BalanceErrorMessage = string.Empty;
                    Balance = double.Parse(value);
                }
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public double Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set
            {
                _nameErrorMessage = value;
                OnPropertyChanged(nameof(NameErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string BalanceErrorMessage
        {
            get => _balanceErrorMessage;
            set
            {
                _balanceErrorMessage = value;
                OnPropertyChanged(nameof(BalanceErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Name) && 
                                 !string.IsNullOrEmpty(BalanceField) &&
                                 double.TryParse(BalanceField, out _) &&
                                 string.IsNullOrEmpty(NameErrorMessage) && 
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTracker.Domain.Models;
using BudgetTracker.WPF.Commands.Create;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;

namespace BudgetTracker.WPF.ViewModels
{
    public class CreateBillFormViewModel : ViewModelBase
    {
        // Bill properties
        private double _amount;
        private string _name;
        private DateTime _dueDate;
        private bool _paid;
        private Category _category;

        // UI Error Messages
        private string _amountErrorMessage;
        private string _nameErrorMessage;
        private string _dueDateErrorMessage;
        private string _paidErrorMessage;
        private string _categoryErrorMessage;
        private string _errorMessage;

        public double Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public bool Paid
        {
            get => _paid;
            set
            {
                _paid = value;
                OnPropertyChanged(nameof(Paid));
            }
        }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string AmountErrorMessage {
            get => _amountErrorMessage;
            set
            {
                _amountErrorMessage = value;
                OnPropertyChanged(nameof(AmountErrorMessage));
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

        public string DueDateErrorMessage
        {
            get => _dueDateErrorMessage;
            set
            {
                _dueDateErrorMessage = value;
                OnPropertyChanged(nameof(DueDateErrorMessage));
            }
        }

        public string PaidErrorMessage
        {
            get => _paidErrorMessage;
            set
            {
                _paidErrorMessage = value;
                OnPropertyChanged(nameof(PaidErrorMessage));
            }
        }

        public string CategoryErrorMessage
        {
            get => _categoryErrorMessage;
            set
            {
                _categoryErrorMessage = value;
                OnPropertyChanged(nameof(CategoryErrorMessage));
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

        public bool CanSubmit => string.IsNullOrEmpty(AmountErrorMessage) &&
                                 string.IsNullOrEmpty(NameErrorMessage) &&
                                 string.IsNullOrEmpty(DueDateErrorMessage) &&
                                 string.IsNullOrEmpty(PaidErrorMessage) &&
                                 string.IsNullOrEmpty(CategoryErrorMessage);

        public ICommand SubmitCommand { get; }

        public CreateBillFormViewModel(IRenavigator renavigator, IUserStore userStore)
        {
            AmountErrorMessage = string.Empty;
            NameErrorMessage = string.Empty;
            DueDateErrorMessage = string.Empty;
            PaidErrorMessage = string.Empty;
            CategoryErrorMessage = string.Empty;
            ErrorMessage = string.Empty;
            SubmitCommand = new CreateBillCommand(this, renavigator, userStore);
        }
    }
}

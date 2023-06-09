using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Create
{
    public class CreateTransactionCommand : AsyncCommandBase
    {
        private readonly CreateTransactionFormViewModel _createTransactionFormViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IUserStore _userStore;

        public CreateTransactionCommand(
            CreateTransactionFormViewModel createTransactionFormViewModel,
            IRenavigator renavigator, IUserStore userStore)
        {
            _createTransactionFormViewModel = createTransactionFormViewModel;
            _renavigator = renavigator;
            _userStore = userStore;

            _createTransactionFormViewModel.PropertyChanged +=
                CreateTransactionFormViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) =>
            _createTransactionFormViewModel.CanSubmit;

        public override async Task ExecuteAsync(object parameter)
        {
            bool errors = false;
            if (_createTransactionFormViewModel.TransactionDate == null)
            {
                _createTransactionFormViewModel.TransactionDateErrorMessage = "This field is required.";
                errors = true;
            }

            if (_createTransactionFormViewModel.Category == null)
            {
                _createTransactionFormViewModel.CategoryErrorMessage = "This field is required.";
                errors = true;
            }

            if (_createTransactionFormViewModel.Account == null)
            {
                _createTransactionFormViewModel.AccountErrorMessage = "This field is required.";
                errors = true;
            }

            if (errors)
            {
                _createTransactionFormViewModel.ErrorMessage = "There are some errors in the form.";
                return;
            }

            _createTransactionFormViewModel.ErrorMessage = string.Empty;
            try
            {
                await _userStore.CreateTransaction(_createTransactionFormViewModel.Name,
                    _createTransactionFormViewModel.Amount,
                    _createTransactionFormViewModel.TransactionDate,
                    _createTransactionFormViewModel.Category,
                    _createTransactionFormViewModel.Account);
                _renavigator.Renavigate();
            }
            catch (Exception)
            {
                _createTransactionFormViewModel.ErrorMessage = "Failed to create transaction.";
            }
        }

        private void CreateTransactionFormViewModel_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateBillFormViewModel.CanSubmit))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Create
{
    public class CreateBillCommand : AsyncCommandBase
    {
        private readonly CreateBillFormViewModel _createBillFormViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IUserStore _userStore;

        public CreateBillCommand(CreateBillFormViewModel createBillFormViewModel,
            IRenavigator renavigator, IUserStore userStore)
        {
            _createBillFormViewModel = createBillFormViewModel;
            _renavigator = renavigator;
            _userStore = userStore;

            _createBillFormViewModel.PropertyChanged += CreateBillFormViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) => _createBillFormViewModel.CanSubmit;

        public override async Task ExecuteAsync(object parameter)
        {
            _createBillFormViewModel.ErrorMessage = string.Empty;
            try
            {
                await _userStore.CreateBill(_createBillFormViewModel.Name,
                    _createBillFormViewModel.DueDate,
                    _createBillFormViewModel.Amount,
                    _createBillFormViewModel.Paid);
                _renavigator.Renavigate();
            }
            catch (Exception)
            {
                _createBillFormViewModel.ErrorMessage = "Failed to create bill.";
            }
        }

        private void CreateBillFormViewModel_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateBillFormViewModel.CanSubmit))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

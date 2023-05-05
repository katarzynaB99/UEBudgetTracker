using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;

namespace BudgetTracker.WPF.Commands.Create
{
    public class CreateAccountCommand : AsyncCommandBase
    {
        private readonly CreateAccountFormViewModel _createAccountFormViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IUserStore _userStore;

        public CreateAccountCommand(CreateAccountFormViewModel createAccountFormViewModel,
            IRenavigator renavigator, IUserStore userStore)
        {
            _createAccountFormViewModel = createAccountFormViewModel;
            _renavigator = renavigator;
            _userStore = userStore;

            _createAccountFormViewModel.PropertyChanged +=
                CreateAccountFormViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) => _createAccountFormViewModel.CanSubmit;

        public override async Task ExecuteAsync(object parameter)
        {
            _createAccountFormViewModel.ErrorMessage = string.Empty;
            var account = await _userStore.CreateAccount(_createAccountFormViewModel.Name,
                    _createAccountFormViewModel.Balance);
            _renavigator.Renavigate();
        }

        private void CreateAccountFormViewModel_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateAccountFormViewModel.CanSubmit))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

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
    public class CreateCategoryCommand : AsyncCommandBase
    {
        private readonly CreateCategoryFormViewModel _createCategoryFormViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IUserStore _userStore;

        public CreateCategoryCommand(CreateCategoryFormViewModel createCategoryFormViewModel,
            IRenavigator renavigator, IUserStore userStore)
        {
            _createCategoryFormViewModel = createCategoryFormViewModel;
            _renavigator = renavigator;
            _userStore = userStore;

            _createCategoryFormViewModel.PropertyChanged += CreateCategoryFormViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) => _createCategoryFormViewModel.CanSubmit;

        public override async Task ExecuteAsync(object parameter)
        {
            _createCategoryFormViewModel.ErrorMessage = string.Empty;
            try
            {
                await _userStore.CreateCategory(_createCategoryFormViewModel.Name);
                _renavigator.Renavigate();
            }
            catch (Exception)
            {
                _createCategoryFormViewModel.ErrorMessage = "Failed to create category.";
            }
        }

        private void CreateCategoryFormViewModel_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateBillFormViewModel.CanSubmit))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

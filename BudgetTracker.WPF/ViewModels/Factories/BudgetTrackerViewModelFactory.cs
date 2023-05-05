using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class BudgetTrackerViewModelFactory : IBudgetTrackerViewModelFactory
    {
        private readonly CreateViewModel<AccountsViewModel> _createAccountsViewModel;
        private readonly CreateViewModel<BillsViewModel> _createBillsViewModel;
        private readonly CreateViewModel<CategoriesViewModel> _createCategoriesViewModel;
        private readonly CreateViewModel<SignInViewModel> _createSignInViewModel;
        private readonly CreateViewModel<SignUpViewModel> _createSignUpViewModel;
        private readonly CreateViewModel<TransactionsViewModel> _createTransactionsViewModel;

        public BudgetTrackerViewModelFactory(
            CreateViewModel<AccountsViewModel> createAccountsViewModel,
            CreateViewModel<BillsViewModel> createBillsViewModel,
            CreateViewModel<CategoriesViewModel> createCategoriesViewModel,
            CreateViewModel<SignInViewModel> createSignInViewModel,
            CreateViewModel<SignUpViewModel> createSignUpViewModel,
            CreateViewModel<TransactionsViewModel> createTransactionsViewModel)
        {
            _createAccountsViewModel = createAccountsViewModel;
            _createBillsViewModel = createBillsViewModel;
            _createCategoriesViewModel = createCategoriesViewModel;
            _createSignInViewModel = createSignInViewModel;
            _createSignUpViewModel = createSignUpViewModel;
            _createTransactionsViewModel = createTransactionsViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType) {
                case ViewType.Accounts:
                    return _createAccountsViewModel();
                case ViewType.Bills:
                    return _createBillsViewModel();
                case ViewType.Categories:
                    return _createCategoriesViewModel();
                case ViewType.SignIn:
                    return _createSignInViewModel();
                case ViewType.SignUp:
                    return _createSignUpViewModel();
                case ViewType.Transactions:
                    return _createTransactionsViewModel();
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.WPF.State.Navigators;

namespace BudgetTracker.WPF.ViewModels.Factories
{
    public class BudgetTrackerViewModelAbstractFactory : IBudgetTrackerViewModelAbstractFactory
    {
        private readonly IBudgetTrackerViewModelFactory<AccountsViewModel> _accountsViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<AnalyticsViewModel> _analyticsViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<BillsViewModel> _billsViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<CategoriesViewModel> _categoriesViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<DashboardViewModel> _dashboardViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<SignInViewModel> _signInViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<SignUpViewModel> _signUpViewModelFactory;
        private readonly IBudgetTrackerViewModelFactory<TransactionsViewModel> _transactionsViewModelFactory;

        public BudgetTrackerViewModelAbstractFactory(
            IBudgetTrackerViewModelFactory<AccountsViewModel> accountsViewModelFactory,
            IBudgetTrackerViewModelFactory<AnalyticsViewModel> analyticsViewModelFactory,
            IBudgetTrackerViewModelFactory<BillsViewModel> billsViewModelFactory,
            IBudgetTrackerViewModelFactory<CategoriesViewModel> categoriesViewModelFactory,
            IBudgetTrackerViewModelFactory<DashboardViewModel> dashboardViewModelFactory,
            IBudgetTrackerViewModelFactory<SignInViewModel> signInViewModelFactory,
            IBudgetTrackerViewModelFactory<SignUpViewModel> signUpViewModelFactory,
            IBudgetTrackerViewModelFactory<TransactionsViewModel> transactionsViewModelFactory)
        {
            _accountsViewModelFactory = accountsViewModelFactory;
            _analyticsViewModelFactory = analyticsViewModelFactory;
            _billsViewModelFactory = billsViewModelFactory;
            _categoriesViewModelFactory = categoriesViewModelFactory;
            _dashboardViewModelFactory = dashboardViewModelFactory;
            _signInViewModelFactory = signInViewModelFactory;
            _signUpViewModelFactory = signUpViewModelFactory;
            _transactionsViewModelFactory = transactionsViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Accounts:
                    return _accountsViewModelFactory.CreateViewModel();
                case ViewType.Analytics:
                    return _analyticsViewModelFactory.CreateViewModel();
                case ViewType.Bills:
                    return _billsViewModelFactory.CreateViewModel();
                case ViewType.Categories:
                    return _categoriesViewModelFactory.CreateViewModel();
                case ViewType.Dashboard:
                    return _dashboardViewModelFactory.CreateViewModel();
                case ViewType.SignIn:
                    return _signInViewModelFactory.CreateViewModel();
                case ViewType.SignUp:
                    return _signUpViewModelFactory.CreateViewModel();
                case ViewType.Transactions:
                    return _transactionsViewModelFactory.CreateViewModel();
                default:
                    throw new NotSupportedException("This type of view model does not exist");
            }
        }
    }
}

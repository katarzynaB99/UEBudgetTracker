using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTrackerWpf.Commands;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;

namespace BudgetTrackerWpf.ViewModels
{
    class NavigationBarViewModel : ViewModelBase
    {
        private readonly UserStore _userStore;

        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateAccountsCommand { get; }
        public ICommand NavigateTransactionsCommand { get; }
        public ICommand NavigateBillsCommand { get; }
        public ICommand NavigateCategoriesCommand { get; }
        public ICommand NavigateAnalyticsCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _userStore.IsLoggedIn;

        public NavigationBarViewModel(UserStore userStore, NavigationStore navigationStore)
        {
            _userStore = userStore;

            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(
                new NavigationService<DashboardViewModel>(navigationStore,
                    () => new DashboardViewModel(navigationStore, userStore)));
            NavigateAccountsCommand = new NavigateCommand<AccountsViewModel>(
                new NavigationService<AccountsViewModel>(navigationStore,
                    () => new AccountsViewModel(navigationStore, userStore)));
            NavigateTransactionsCommand = new NavigateCommand<TransactionsViewModel>(
                new NavigationService<TransactionsViewModel>(navigationStore,
                    () => new TransactionsViewModel(navigationStore, userStore)));
            NavigateBillsCommand = new NavigateCommand<BillsViewModel>(
                new NavigationService<BillsViewModel>(navigationStore,
                    () => new BillsViewModel(navigationStore, userStore)));
            NavigateCategoriesCommand = new NavigateCommand<CategoriesViewModel>(
                new NavigationService<CategoriesViewModel>(navigationStore,
                    () => new CategoriesViewModel(navigationStore, userStore)));
            NavigateAnalyticsCommand = new NavigateCommand<AnalyticsViewModel>(
                new NavigationService<AnalyticsViewModel>(navigationStore,
                    () => new AnalyticsViewModel(navigationStore, userStore)));
            LogoutCommand = new LogoutCommand(userStore,
                new NavigationService<LoginViewModel>(navigationStore,
                    () => new LoginViewModel(navigationStore, userStore)));

            _userStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _userStore.CurrentUserChanged -= OnCurrentUserChanged;

            base.Dispose();
        }
    }
}

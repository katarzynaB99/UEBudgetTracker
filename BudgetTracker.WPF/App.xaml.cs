using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using BudgetTracker.Domain.Services.AuthenticationServices;
using BudgetTracker.EntityFramework;
using BudgetTracker.EntityFramework.Services;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;
using BudgetTracker.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracker.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<BudgetTrackerDbContextFactory>();

            services.AddSingleton<ITransactionService, TransactionDataService>();
            services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
            services.AddSingleton<IBillService, BillDataService>();
            services.AddSingleton<IDataService<Category>, GenericDataService<Category>>();
            services
                .AddSingleton<IDataService<TransactionType>, GenericDataService<TransactionType>>();
            services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services
                .AddSingleton<IBudgetTrackerViewModelAbstractFactory,
                    BudgetTrackerViewModelAbstractFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<AccountsViewModel>,
                    AccountsViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<AnalyticsViewModel>,
                    AnalyticsViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<BillsViewModel>, BillsViewModelFactory
                >();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<CategoriesViewModel>,
                    CategoriesViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<DashboardViewModel>,
                    DashboardViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<SignInViewModel>,
                    SignInViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<SignUpViewModel>,
                    SignUpViewModelFactory>();
            services
                .AddSingleton<IBudgetTrackerViewModelFactory<TransactionsViewModel>,
                    TransactionsViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s =>
                new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}

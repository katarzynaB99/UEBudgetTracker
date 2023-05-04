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
using BudgetTracker.WPF.State.Assets;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.State.Users;
using BudgetTracker.WPF.ViewModels;
using BudgetTracker.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracker.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Database context
            services.AddSingleton<BudgetTrackerDbContextFactory>();

            // Add Services
            services.AddSingleton<ITransactionService, TransactionDataService>();
            services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
            services.AddSingleton<IBillService, BillDataService>();
            services.AddSingleton<IDataService<Category>, GenericDataService<Category>>();
            services
                .AddSingleton<IDataService<TransactionType>, GenericDataService<TransactionType>>();
            services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // Register View Models
            services.AddTransient<AccountsViewModel>();
            services.AddTransient<AnalyticsViewModel>();
            services.AddTransient<BillsViewModel>();
            services.AddTransient<CategoriesViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<TransactionsViewModel>();

            services.AddSingleton<CreateViewModel<AccountsViewModel>>(services =>
            {
                return () => services.GetRequiredService<AccountsViewModel>();
            });
            services.AddSingleton<CreateViewModel<AnalyticsViewModel>>(services =>
            {
                return () => services.GetRequiredService<AnalyticsViewModel>();
            });
            services.AddSingleton<CreateViewModel<BillsViewModel>>(services =>
            {
                return () => services.GetRequiredService<BillsViewModel>();
            });
            services.AddSingleton<CreateViewModel<CategoriesViewModel>>(services =>
            {
                return () => services.GetRequiredService<CategoriesViewModel>();
            });
            services.AddSingleton<CreateViewModel<DashboardViewModel>>(services =>
            {
                return () => services.GetRequiredService<DashboardViewModel>();
            });
            services.AddSingleton<CreateViewModel<SignInViewModel>>(services =>
            {
                return () => new SignInViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelFactoryRenavigator<DashboardViewModel>>(),
                    services.GetRequiredService<ViewModelFactoryRenavigator<SignUpViewModel>>());
            });
            services.AddSingleton<CreateViewModel<SignUpViewModel>>(services =>
            {
                return () => services.GetRequiredService<SignUpViewModel>();
            });
            services.AddSingleton<CreateViewModel<TransactionsViewModel>>(services =>
            {
                return () => services.GetRequiredService<TransactionsViewModel>();
            });

            services.AddSingleton<IBudgetTrackerViewModelFactory, BudgetTrackerViewModelFactory>();

            services.AddSingleton<ViewModelFactoryRenavigator<DashboardViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<SignInViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<SignUpViewModel>>();

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IUserStore, UserStore>();
            services.AddSingleton<AssetStore>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s =>
                new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}

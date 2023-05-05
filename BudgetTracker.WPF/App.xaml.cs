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
using BudgetTracker.WPF.Views;
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
            services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // Register View Models
            services.AddTransient<AccountsViewModel>();
            services.AddTransient<BillsViewModel>();
            services.AddTransient<CategoriesViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<TransactionsViewModel>();

            services.AddTransient<CreateAccountFormViewModel>();
            services.AddTransient<CreateBillFormViewModel>();
            services.AddTransient<CreateCategoryFormViewModel>();
            services.AddTransient<CreateTransactionFormViewModel>();

            services.AddTransient<UpdateAccountFormViewModel>();
            services.AddTransient<UpdateBillFormViewModel>();
            services.AddTransient<UpdateCategoryFormViewModel>();
            services.AddTransient<UpdateTransactionFormViewModel>();

            services.AddSingleton<CreateViewModel<AccountsViewModel>>(services =>
            {
                return () => new AccountsViewModel(
                    services.GetRequiredService<IUserStore>(),
                    services.GetRequiredService<ViewModelFactoryRenavigator<CreateAccountFormViewModel>>());
            });
            services.AddSingleton<CreateViewModel<BillsViewModel>>(services =>
            {
                return () => services.GetRequiredService<BillsViewModel>();
            });
            services.AddSingleton<CreateViewModel<CategoriesViewModel>>(services =>
            {
                return () => services.GetRequiredService<CategoriesViewModel>();
            });
            services.AddSingleton<CreateViewModel<SignInViewModel>>(services =>
            {
                return () => new SignInViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelFactoryRenavigator<AccountsViewModel>>(),
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

            services.AddSingleton<CreateViewModel<CreateAccountFormViewModel>>(services =>
            {
                return () => new CreateAccountFormViewModel(
                    services.GetRequiredService<ViewModelFactoryRenavigator<AccountsViewModel>>(),
                    services.GetRequiredService<IUserStore>());
            });
            services.AddSingleton<CreateViewModel<CreateBillFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<CreateBillFormViewModel>();
            });
            services.AddSingleton<CreateViewModel<CreateCategoryFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<CreateCategoryFormViewModel>();
            });
            services.AddSingleton<CreateViewModel<CreateTransactionFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<CreateTransactionFormViewModel>();
            });

            services.AddSingleton<CreateViewModel<UpdateAccountFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<UpdateAccountFormViewModel>();
            });
            services.AddSingleton<CreateViewModel<UpdateBillFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<UpdateBillFormViewModel>();
            });
            services.AddSingleton<CreateViewModel<UpdateCategoryFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<UpdateCategoryFormViewModel>();
            });
            services.AddSingleton<CreateViewModel<UpdateTransactionFormViewModel>>(services =>
            {
                return () => services.GetRequiredService<UpdateTransactionFormViewModel>();
            });

            services.AddSingleton<IBudgetTrackerViewModelFactory, BudgetTrackerViewModelFactory>();

            services.AddSingleton<ViewModelFactoryRenavigator<SignInViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<SignUpViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<AccountsViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<BillsViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<TransactionsViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<CategoriesViewModel>>();

            services.AddSingleton<ViewModelFactoryRenavigator<CreateAccountFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<CreateBillFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<CreateCategoryFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<CreateTransactionFormViewModel>>();
            
            services.AddSingleton<ViewModelFactoryRenavigator<UpdateAccountFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<UpdateBillFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<UpdateCategoryFormViewModel>>();
            services.AddSingleton<ViewModelFactoryRenavigator<UpdateTransactionFormViewModel>>();

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

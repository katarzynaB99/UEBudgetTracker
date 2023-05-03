using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using BudgetTracker.EntityFramework;
using BudgetTracker.EntityFramework.Services;
using BudgetTracker.WPF.ViewModels;
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
            ITransactionService transactionService = new TransactionDataService(new BudgetTrackerDbContextFactory());
            IDataService<Account> accountService = new GenericDataService<Account>(new BudgetTrackerDbContextFactory());
            IBillService billService = new BillDataService(new BudgetTrackerDbContextFactory());
            IDataService<Category> categoryService = new GenericDataService<Category>(new BudgetTrackerDbContextFactory());
            IDataService<TransactionType> transactionTypeService = new GenericDataService<TransactionType>(new BudgetTrackerDbContextFactory());
            IDataService<User> userService = new GenericDataService<User>(new BudgetTrackerDbContextFactory());

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}

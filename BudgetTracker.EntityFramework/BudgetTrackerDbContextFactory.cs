using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BudgetTracker.EntityFramework
{
    public class BudgetTrackerDbContextFactory : IDesignTimeDbContextFactory<BudgetTrackerDbContext>
    {
        public BudgetTrackerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<BudgetTrackerDbContext>();

            // Get path to the AppData directory
            var applicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BudgetTracker");
            // Create the directory if it doesn't exist
            Directory.CreateDirectory(applicationDataPath);
            var sqlitePath = Path.Combine(applicationDataPath, "BudgetTracker.db");
            options.UseSqlite("Data Source=" + sqlitePath);

            var context = new BudgetTrackerDbContext(options.Options);

            // Create all the tables if the database did not exist before
            context.Database.EnsureCreated();

            return context;
        }
    }
}

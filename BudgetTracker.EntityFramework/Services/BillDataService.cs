using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;
using BudgetTracker.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.EntityFramework.Services
{
    public class BillDataService : GenericDataService<Bill>, IBillService
    {
        private readonly BudgetTrackerDbContextFactory _contextFactory;

        public BillDataService(BudgetTrackerDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Bill>> GetBillsByPayStatus(int userId, bool paid)
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Bill> entities = await context.Bills
                .Where(e => e.User.Id == userId && e.Paid == paid)
                .OrderBy(e => e.DueDate)
                .ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Bill>> GetOverdueBills(int userId)
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Bill> entities = await context.Bills
                .Where(e => e.User.Id == userId && !e.Paid && e.DueDate < DateTime.Now)
                .OrderBy(e => e.DueDate)
                .ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Bill>> GetBillsByUser(int userId)
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Bill> entities = await context.Bills
                .Where(e => e.User.Id == userId)
                .OrderBy(e => e.DueDate)
                .ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Bill>> GetUpcomingBills(int userId, int numberOfBills)
        {
            await using var context = _contextFactory.CreateDbContext();
            IEnumerable<Bill> entities = await context.Bills
                .Where(e => e.User.Id == userId && !e.Paid)
                .OrderBy(e => e.DueDate)
                .ToListAsync();
            return entities;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Domain.Models;

namespace BudgetTracker.Domain.Services
{
    public interface IBillService : IDataService<Bill>
    {
        Task<IEnumerable<Bill>> GetBillsByPayStatus(int userId, bool paid);
        Task<IEnumerable<Bill>> GetOverdueBills(int userId);
        Task<IEnumerable<Bill>> GetBillsByUser(int userId);
        Task<IEnumerable<Bill>> GetUpcomingBills(int userId, int numberOfBills);
    }
}

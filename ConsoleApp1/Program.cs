using BudgetTracker.Domain.Services;
using System;
using System.IO;
using System.Linq;
using BudgetTracker.Domain.Models;
using BudgetTracker.EntityFramework;
using BudgetTracker.EntityFramework.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService =
                new GenericDataService<User>(new BudgetTrackerDbContextFactory());
            userService.Create(new User {Username = "Test", Password = "Test", CreationDate = DateTime.Now}).Wait();
            Console.WriteLine(userService.GetAll().Result.Count());
            Console.ReadLine();
        }
    }
}

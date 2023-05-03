using System;
using System.Collections.Generic;
using System.Text;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;
using BudgetTrackerWpf.ViewModels;

namespace BudgetTrackerWpf.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly UserStore _userStore;
        private readonly NavigationService<LoginViewModel> _navigationService;

        public LogoutCommand(UserStore userStore, NavigationService<LoginViewModel> navigationService)
        {
            _userStore = userStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _userStore.Logout();
            _navigationService.Navigate();
        }
    }
}

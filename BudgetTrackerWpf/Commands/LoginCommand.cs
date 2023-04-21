using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BudgetTrackerWpf.Models;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;
using BudgetTrackerWpf.ViewModels;

namespace BudgetTrackerWpf.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly UserStore _userStore;
        private readonly string path = "https://localhost:5001/api/Users";

        private readonly NavigationService<DashboardViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, UserStore userStore, NavigationService<DashboardViewModel> navigationService)
        {
            _viewModel = viewModel;
            _userStore = userStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            // TODO: Contact the API to properly authenticate
            User user = new User()
            {
                Username = _viewModel.Username,
            };

            _userStore.CurrentUser = user;
            _navigationService.Navigate();
        }
    }
}

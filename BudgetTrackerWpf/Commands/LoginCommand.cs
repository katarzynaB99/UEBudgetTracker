using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Input;
using BudgetTrackerWpf.Models;
using BudgetTrackerWpf.Models.Dtos;
using BudgetTrackerWpf.Services;
using BudgetTrackerWpf.Stores;
using BudgetTrackerWpf.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BudgetTrackerWpf.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly UserStore _userStore;
        private readonly string path = "https://localhost:5001/api/Login";

        private readonly NavigationService<DashboardViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, UserStore userStore,
            NavigationService<DashboardViewModel> navigationService)
        {
            _viewModel = viewModel;
            _userStore = userStore;
            _navigationService = navigationService;
        }

        public override async void Execute(object parameter)
        {
            using var client = new HttpClient();
            var loginDetails = new LoginDto
            {
                Username = _viewModel.Username,
                Password = _viewModel.Password
            };
            var loginJson = JsonConvert.SerializeObject(loginDetails);
            var buffer = System.Text.Encoding.UTF8.GetBytes(loginJson);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(path, byteContent);

            if (response.IsSuccessStatusCode)
            {
                var jwtToken = await response.Content.ReadAsStringAsync();
                _userStore.JwtToken = jwtToken;
                var user = new User()
                {
                    Username = _viewModel.Username
                };
                _userStore.CurrentUser = user;
                _navigationService.Navigate();
            }
            else
            {
                _viewModel.ErrorMessage = response.StatusCode == HttpStatusCode.NotFound
                    ? "Invalid username or password."
                    : "Connection to the server failed.";

            }
        }
    }
}

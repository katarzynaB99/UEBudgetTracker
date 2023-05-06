using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetTracker.WPF.State.Authenticators;
using BudgetTracker.WPF.State.Navigators;
using BudgetTracker.WPF.ViewModels;
using BudgetTracker.WPF.Views;

namespace BudgetTracker.WPF.Commands
{
    public class SignOutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public SignOutCommand(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _authenticator.SignOut();
            _renavigator.Renavigate();
        }

        public event EventHandler CanExecuteChanged;
    }
}

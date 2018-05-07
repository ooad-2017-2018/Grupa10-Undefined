using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicBox.ViewModels.LoginCommands
{
    public class LoginAsGuestCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }
        public LoginAsGuestCommand(LoginViewModel loginViewModel)
        {
            this.LoginViewModel = loginViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.LoginViewModel.LoginAsGuest();
        }
    }
}

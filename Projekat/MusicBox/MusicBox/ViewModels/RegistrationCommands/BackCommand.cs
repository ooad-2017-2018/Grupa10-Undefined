using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicBox.ViewModels.RegistrationCommands
{
    public class BackCommand : ICommand
    {
        public RegistrationViewModel RegistrationViewModel { get; set; }
        public BackCommand(RegistrationViewModel registrationViewModel)
        {
            this.RegistrationViewModel = registrationViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.RegistrationViewModel.Back();
        }
    }
}

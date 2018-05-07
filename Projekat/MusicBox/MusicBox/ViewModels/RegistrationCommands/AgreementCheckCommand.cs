using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicBox.ViewModels.RegistrationCommands
{
    public class AgreementCheckCommand : ICommand
    {
        public RegistrationViewModel RegistrationViewModel { get; set; }
        public AgreementCheckCommand(RegistrationViewModel registrationViewModel)
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
            if (RegistrationViewModel.TermsOfLicence)
                RegistrationViewModel.TermsOfLicence = false;
            else RegistrationViewModel.TermsOfLicence = true;
        }
    }
}

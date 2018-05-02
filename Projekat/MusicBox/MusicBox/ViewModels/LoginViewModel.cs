using GalaSoft.MvvmLight.Command;
using MusicBox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MusicBox.ViewModels
{
    public class LoginViewModel
    {
        User loggedUser;
        string _username = "";
        string _password = "";
        ICommand loginButtonClicked;

        public ICommand LoginButtonClicked {
            get
            {
                return loginButtonClicked ??
                    (loginButtonClicked = new RelayCommand<PasswordBox>(param => this.login(param)));
            }
        }
        public User LoggedUser { get => loggedUser; set => loggedUser = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        
        async public void login(object param)
        {
            _password = (param as PasswordBox).Password;
            bool success = validateLoginData();
            //TODO izvrsi prijavu
            var dialog = new MessageDialog("HEHE");
            await dialog.ShowAsync();
        }
        
        bool validateLoginData()
        {
            return true;
            //TODO izracunati hash passworda prije poredjenja i provjeriti kako cuvati data u user i registeredUser klasama
            //TODO dodati praznu listu za pocetak u MusicBox.Users
            return MusicBoxClass.Users.Find(x => x.Username == Username && x.Password == Password) != null;            
        }
    }
}

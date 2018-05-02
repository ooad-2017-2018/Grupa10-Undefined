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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MusicBox.ViewModels
{

    public interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
    }

    public sealed class NavigationService : INavigationService
    {
        public void Navigate(Type sourcePage)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            frame.GoBack();
        }
    }

    public class LoginViewModel
    {
        User loggedUser;
        string _username = "";
        string _password = "";
        ICommand loginButtonClicked;
        ICommand loginGuestButtonClicked;
        ICommand registrationButtonClicked;
        INavigationService _navigationService;

        public ICommand LoginButtonClicked {
            get
            {
                return loginButtonClicked ??
                    (loginButtonClicked = new RelayCommand<PasswordBox>(param => this.login(param)));
            }
        }

        public ICommand LoginGuestButtonClicked
        {
            get
            {
                return loginGuestButtonClicked ??
                    (loginGuestButtonClicked = new RelayCommand(loginGuest));
            }
        }

        public ICommand RegistrationButtonClicked
        {
            get
            {
                return registrationButtonClicked ??
                    (registrationButtonClicked = new RelayCommand(registration));
            }
        }
        public User LoggedUser { get => loggedUser; set => loggedUser = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        async public void login(object param)
        {

            _navigationService.Navigate(typeof(Administration));
            _password = (param as PasswordBox).Password;
            bool success = validateLoginData();
            //TODO izvrsi prijavu
            var dialog = new MessageDialog("OBICNI LOGIN");
            await dialog.ShowAsync();
        }

        async public void loginGuest()
        {
            var dialog = new MessageDialog("GUEST LOGIN");
            await dialog.ShowAsync();
        }
        
        async public void registration()
        {
            var dialog = new MessageDialog("REGISTRATION");
            await dialog.ShowAsync();
        }

        bool validateLoginData()
        {
            return true;
            //TODO izracunati hash passworda prije poredjenja i provjeriti kako cuvati data u user i registeredUser klasama
            //TODO dodati praznu listu za pocetak u MusicBox.Users
            Password = RegisteredUser.calculateHash(Password);
            return MusicBoxClass.Users.Find(x => x.Username == Username && x.Password == Password) != null;            
        }
    }
}

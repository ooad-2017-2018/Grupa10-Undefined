using GalaSoft.MvvmLight.Command;
using MusicBox.Models;
using MusicBox;
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
using MusicBox.ViewModels.LoginCommands;
using System.Reflection.Metadata;
using System.Data.SqlClient;

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
        int id = -1;
        string _connectionString;
        string _username = "";
        string _password = "";
        public LoginCommand LoginCommand { get; set; }
        public LoginAsGuestCommand LoginAsGuestCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }
        NavigationService NavigationService { get; set; }

        INavigationService _navigationService;

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            this.LoginCommand = new LoginCommand(this);
            this.LoginAsGuestCommand = new LoginAsGuestCommand(this);
            this.RegisterCommand = new RegisterCommand(this);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ooad-g10-undefined.database.windows.net";
            builder.UserID = "esehovic2";
            builder.Password = "esehovic#2";
            builder.InitialCatalog = "MusicBoxDB";
            _connectionString = builder.ConnectionString;
        }
        async public void Login()
        {
            if(Username == "Admin" && Password == "TheBoss")
            {
                _navigationService.Navigate(typeof(MusicBox.Views.Administration_v2));
            }
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT u.id
                                              FROM User u
                                              WHERE u.username = '" + Username + "' AND u.password = '" + Password + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    id = int.Parse(dr.GetString(0));
                    var dialog = new MessageDialog("Obisni Login!");
                    await dialog.ShowAsync();
                }
            }
            if(id == -1)
            {
                var dialog = new MessageDialog("Nema jos Registrovanih!");
                await dialog.ShowAsync();
            }
            con.Close();
        }
        public void Register()
        {
            _navigationService.Navigate(typeof(MusicBox.Views.Registration));
        }
        async public void LoginAsGuest()
        {
            var dialog = new MessageDialog("Guest Login!");
            await dialog.ShowAsync();
        }
        public User LoggedUser { get => loggedUser; set => loggedUser = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
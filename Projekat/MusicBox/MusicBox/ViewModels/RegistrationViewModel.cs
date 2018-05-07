using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Models;
using MusicBox.ViewModels.RegistrationCommands;
using Windows.UI.Popups;

namespace MusicBox.ViewModels
{
    public class RegistrationViewModel
    {
        RegisteredUser logedUser;
        string _connectionString;
        string firstName;
        string lastName;
        string username;
        string password;
        string confirmPassowrd;
        Boolean termsOfLicence;
        NavigationService NavigationService { get; set; }
        public BackCommand BackCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }
        public AgreementCheckCommand AgreementCheckCommand { get; set; }
        INavigationService navigationService;
        public RegistrationViewModel()
        {
            navigationService = new NavigationService();
            this.BackCommand = new BackCommand(this);
            this.RegisterCommand = new RegisterCommand(this);
            this.AgreementCheckCommand = new AgreementCheckCommand(this);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ooad-g10-undefined.database.windows.net";
            builder.UserID = "esehovic2";
            builder.Password = "esehovic#2";
            builder.InitialCatalog = "MusicBoxDB";
            _connectionString = builder.ConnectionString;
        }

        public void Back()
        {
            navigationService.Navigate(typeof(MusicBox.MainPage));
        }
        public async void RegisterAsync()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT u.id   FROM User u
                                              WHERE u.username = '" + Username + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                var dialog = new MessageDialog("Username u upotrebi");
                await dialog.ShowAsync();
            }
            else
            {
                if (Validate())
                {
                    logedUser = new RegisteredUser(Username, Password, FirstName, LastName);
                    cmd.CommandText = @"INSERT INTO USERS(ID, username, password, name, lastname, banned)
                                   VALUES (1, '" + logedUser.Username + "', '" + logedUser.Password + "', '" + logedUser.Name +
                                       "', '" + logedUser.LastName + "', '" + logedUser.Banned + "')";
                    var dialog = new MessageDialog("Korisnik je registrovan!");
                    await dialog.ShowAsync();
                    navigationService.Navigate(typeof(MusicBox.MainPage));
                }
                else
                {
                    var dialog = new MessageDialog("Unesite sve podatke!");
                    await dialog.ShowAsync();
                }
            }
            con.Close();
        }
        public RegistrationViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool TermsOfLicence { get => termsOfLicence; set => termsOfLicence = value; }
        public string ConfirmPassowrd { get => confirmPassowrd; set => confirmPassowrd = value; }
        Boolean Validate()
        {
            if (FirstName != null && LastName != null && Username != null && Password != null)
                return true;
            return false;
        }
    }
}

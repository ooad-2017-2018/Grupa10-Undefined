using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using MusicBox.Models;
using System.Threading;
//TEMPORARILY
using System.Data.SqlClient;


namespace MusicBox.ViewModels
{
    public class AdministrationViewModel : INotifyPropertyChanged
    {
        string _connectionString;
        string _username;
        public ObservableCollection<String> UserReportsList { get; set; }
        public ObservableCollection<String> SongReportsList { get; set; }
        public ObservableCollection<User> SearchResults { get; set; }
        ICommand searchButtonClick;
        ICommand userReportsRefreshClick;
        ICommand songReportsRefreshClick;

        public AdministrationViewModel()
        {
            UserReportsList = new ObservableCollection<string>();
            SearchResults = new ObservableCollection<User>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ooad-g10-undefined.database.windows.net";
            builder.UserID = "esehovic2";
            builder.Password = "esehovic#2";
            builder.InitialCatalog = "MusicBoxDB";
            _connectionString = builder.ConnectionString;
        }
        
        public ICommand SearchButtonClick
        {
            get
            {
                return searchButtonClick ??
                    (searchButtonClick = new RelayCommand(fillListView));
                   //  (searchButtonClick = new RelayCommand<ListView>(param => this.fillListView(param)));
            }
        }

        public string Username { get => _username; set => _username = value; }


        public ICommand UserReportsRefreshClick
        {
            get
            {
                return userReportsRefreshClick ??
                    (userReportsRefreshClick = new RelayCommand(userRefresh));
            }
        }        

        public ICommand SongReportsRefreshClick
        {
            get
            {
                return songReportsRefreshClick ??
                    (songReportsRefreshClick = new RelayCommand(songRefresh));
            }
        }

        void userRefresh()
        {                        
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT u.username
                                                FROM USERS u, USER_REPORTS r
                                                WHERE u.ID = r.USER_ID", con);
            SqlDataReader dr = cmd.ExecuteReader();
            UserReportsList.Clear();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    string retVal = dr.GetString(0);
                    UserReportsList.Add(retVal);
                    //var dialog = new MessageDialog(retVal);
                    //await dialog.ShowAsync();
                }
            }
            con.Close();            
        }

        async void songRefresh()
        {
            var dialog = new MessageDialog("Binding successful");
            await dialog.ShowAsync();
        }

        async void fillListView()
        {
            //  SearchResults = new ObservableCollection<string>();

            // SearchResults.Add(new RegisteredUser("ABC","abc","abc","abc"));
            // SearchResults.Add("ABC");
            // SearchResults.Add("ABC");

            //SqlConnection conSession = new SqlConnection("Server = tcp:ooad-g10-undefined.database.windows.net,1433; Initial Catalog = MusicBoxDB; Persist Security Info = False; User ID = {esehovic2}; Password ={esehovic#2}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ooad-g10-undefined.database.windows.net";
            builder.UserID = "esehovic2";
            builder.Password = "esehovic#2";
            builder.InitialCatalog = "MusicBoxDB";

            SqlConnection conSession = new SqlConnection(builder.ConnectionString);
            conSession.Open();                     
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conSession;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO USERS(ID, username, password, name, lastname, banned) " +
                 "               VALUES (1, 'abc', 'abcd', 'aaa', 'bbb', 'FALSE')";
              
            
            cmd.ExecuteNonQuery(); 
            conSession.Close();
            
            var dialog = new MessageDialog(SearchResults.Count.ToString());
            await dialog.ShowAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

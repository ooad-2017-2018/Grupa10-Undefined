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
        string _searchSubstring = "";
        string _strBanDuration = "";
        int _selectedIndexVar = -3;
        string _selectedUsername = "";
        public ObservableCollection<String> UserReportsList { get; set; }
        public ObservableCollection<String> SongReportsList { get; set; }
        public ObservableCollection<String> SearchResults { get; set; }
        ICommand searchButtonClick;
        ICommand userReportsRefreshClick;
        ICommand songReportsRefreshClick;
        ICommand searchClick;
        ICommand banClick;
        ICommand removeClick;

        public AdministrationViewModel()
        {
            UserReportsList = new ObservableCollection<string>();
            SongReportsList = new ObservableCollection<string>();
            SearchResults = new ObservableCollection<string>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ooad-g10-undefined.database.windows.net";
            builder.UserID = "esehovic2";
            builder.Password = "esehovic#2";
            builder.InitialCatalog = "MusicBoxDB";
            _connectionString = builder.ConnectionString;
        }
        
        //OVO JE ZAPRAVO DODAVANJE NOVIH USERA
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
        public string SearchSubstring { get => _searchSubstring; set => _searchSubstring = value; }
        public string StrBanDuration { get => _strBanDuration; set => _strBanDuration = value; }
        public int SelectedIndexVar { get => _selectedIndexVar; set => _selectedIndexVar = value; }
        public string SelectedUsername { get => _selectedUsername; set => _selectedUsername = value; }

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

        public ICommand SearchClick
        {
            get
            {
                return searchClick ??
                    (searchClick = new RelayCommand(executeSearch));
            }
        }
        
        public ICommand BanClick
        {
            get
            {
                return banClick ??
                    (banClick = new RelayCommand(executeBan));
            }
        }

        public ICommand RemoveClick
        {
            get
            {
                return removeClick??
                    (removeClick = new RelayCommand(executeRemove));
            }
        }


        void executeSearch()
        {
            SearchResults.Clear();
            if (SearchSubstring.Length != 0)
            {
                SearchSubstring = SearchSubstring.ToUpper();
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT u.username
                                                FROM USERS u
                                                WHERE UPPER(u.username) LIKE '%" + SearchSubstring + "%'", con);
                SqlDataReader dr = cmd.ExecuteReader();             
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string retVal = dr.GetString(0);
                        SearchResults.Add(retVal);                   
                    }
                }
                con.Close();                
            }           
        }

        async void executeBan()
        {
            int retVal = 0;
            Int32.TryParse(StrBanDuration, out int banDuration);
            if(SelectedIndexVar != -1 && banDuration != 0)
            {
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT u.ID
                                     FROM USERS u
                                     WHERE u.username = '" + SelectedUsername + "'", con);
               
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        retVal = dr.GetInt32(0);
                    }
                }
                dr.Close();

                cmd = new SqlCommand(@"UPDATE USERS
                                     SET banned = 'TRUE'
                                     WHERE ID = " + retVal, con);

                cmd.ExecuteNonQuery();
                
                cmd = new SqlCommand(@"DELETE
                                     FROM BANNED_USERS
                                     WHERE ID = " + retVal, con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(@"INSERT INTO BANNED_USERS(ID, unbanDate) VALUES (" + retVal + ", '" + DateTime.Now.AddDays(banDuration).ToString("yyyy-MM-dd HH:mm:ss")  + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                var dialog2 = new MessageDialog("Korisnik je uspjesno banovan!");
                await dialog2.ShowAsync();
            }            
        }

        async void executeRemove()
        {
            if(SelectedIndexVar != -1)
            {
                int retVal = 0;
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT u.ID
                                     FROM USERS u
                                     WHERE u.username = '" + SelectedUsername + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        retVal = dr.GetInt32(0);
                    }
                }
                dr.Close();

                cmd = new SqlCommand(@"DELETE
                                     FROM USERS 
                                     WHERE ID = " + retVal, con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(@"DELETE
                                     FROM BANNED_USERS 
                                     WHERE ID = " + retVal, con);
                cmd.ExecuteNonQuery();
                con.Close();

                SearchResults.RemoveAt(SelectedIndexVar);
                var dialog = new MessageDialog("Korisnik je uspjesno izbrisan!");
                await dialog.ShowAsync();
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
                }
            }
            con.Close();
        }

        void songRefresh()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT s.name
                                                FROM SONGS s, SONG_REPORTS r
                                                WHERE s.ID = r.SONG_ID", con);
            SqlDataReader dr = cmd.ExecuteReader();
            SongReportsList.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string retVal = dr.GetString(0);
                    SongReportsList.Add(retVal);
                }
            }
            con.Close();            
        }

        //DODAVANJE NOVIH USERA
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
            cmd.CommandText = @"INSERT INTO USERS(ID, username, password, name, lastname, banned) " +
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

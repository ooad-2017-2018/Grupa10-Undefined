using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Models;
using Google.Apis.YouTube.v3;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

using YoutubeSearch;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
//using Google.Apis.YouTube.v3.Data;

namespace MusicBox.ViewModels
{
    public class RegisteredUserViewModel
    {
        RegisteredUser loggedUser;

        string _searchSubstring = "";
        ICommand searchClick;
        ICommand playClick;
        public ObservableCollection<VideoInformation> SearchResults { get; set; }

        public RegisteredUserViewModel()
        {

        }

        public RegisteredUserViewModel(User u)
        {
            loggedUser = (RegisteredUser)u;
            SearchResults = new ObservableCollection<VideoInformation>();
        }

        public ICommand SearchClick
        {
            get
            {
                return searchClick ??
                    (searchClick = new RelayCommand(execSearchAsync));
                //  (searchButtonClick = new RelayCommand<ListView>(param => this.fillListView(param)));
            }
        }

        /*public ICommand PlayClick
        {
            get
            {
                return playClick ??
                    (playClick = new RelayCommand(execPlayAsync));
                //  (searchButtonClick = new RelayCommand<ListView>(param => this.fillListView(param)));
            }
        }*/


        public string SearchSubstring { get => _searchSubstring; set => _searchSubstring = value; }

        public async void execSearchAsync()
        {
            SearchResults.Clear();
            VideoSearch items = new VideoSearch();
            //List<Video> list = new List<Video>();
            
            //SearchResults = items.SearchQuery("greenday", 1);
            
            foreach (var item in items.SearchQuery(SearchSubstring, 1))
            {
                SearchResults.Add(item);
            }
           
        }       


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MusicBox.ViewModels;
using Windows.UI.Popups;
using Windows.Media.Playback;



using MyToolkit;
using MyToolkit.Multimedia;
using YoutubeSearch;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicBox.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisteredUser : Page
    {

        public RegisteredUser()
        {
            this.InitializeComponent();
           // this.DataContext = new RegisteredUserViewModel();

            
        }

        async protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new RegisteredUserViewModel((Models.User)e.Parameter);
            
            /*
            MediaPlayer mp = new MediaPlayer();
            string YouTubeId = "KvKML4TTyjQ";
            YouTubeUri url = await YouTube.GetVideoUriAsync(YouTubeId, YouTubeQuality.Quality360P);
            mp.SetUriSource(url.Uri);
            
            mp.Play();
            

            


            mPlayer.SetMediaPlayer(mp);
            */
           
        }

        public async void execPlayAsync(object sender)
        {
            var dialog = new MessageDialog("Korisnik je uspjesno izbrisan!");
            await dialog.ShowAsync();
        }

        private async void mPlayer_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            string text = "";
            if (listSearchResults.SelectedIndex != -1)
            {
                text = (listSearchResults.Items[listSearchResults.SelectedIndex] as VideoInformation).Url;
                int i = 0;
                for(i = 0; i < text.Length; i++)
                {
                    if (text[i] == '=')
                        break;
                }
                i++;
                text = text.Substring(i);
                MediaPlayer mp = new MediaPlayer();
                string YouTubeId = text;
                
                YouTubeUri url = await YouTube.GetVideoUriAsync(YouTubeId, YouTubeQuality.NotAvailable);
                mp.SetUriSource(url.Uri);
                mp.Play();
                mPlayer.SetMediaPlayer(mp);

                // mPlayer.SetMediaPlayer(mp);
                /*MediaPlayer mp = new MediaPlayer();
                string YouTubeId = "KvKML4TTyjQ";
                YouTubeUri url = await YouTube.GetVideoUriAsync(YouTubeId, YouTubeQuality.Quality360P);
                mp.SetUriSource(url.Uri);*/
            }
            
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));          
        }
    }
}

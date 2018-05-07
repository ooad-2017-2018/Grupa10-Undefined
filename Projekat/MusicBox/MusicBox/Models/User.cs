using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public abstract class User
    {
        Song currSong;
        string username;
        string password;
        public Song CurrSong { get => currSong; set => currSong = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}

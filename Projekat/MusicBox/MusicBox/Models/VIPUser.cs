using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public sealed class VIPUser : RegisteredUser
    {
        List<Song> uploadedSongs;
        List<Event> myEvents;

        public List<Song> UploadedSongs { get => uploadedSongs; set => uploadedSongs = value; }
        public List<Event> MyEvents { get => myEvents; set => myEvents = value; }

        public VIPUser(string username, string pw, string name, string lastname) : base(username, pw, name, lastname)
        {
            UploadedSongs = new List<Song>();
            MyEvents = new List<Event>();
        }
    }
}

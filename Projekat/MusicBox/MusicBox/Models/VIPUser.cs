using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public sealed class VIPUser : User
    {
        static int ID_COUNTER = 0;
        int id;
        string name;
        string lastName;
        bool banned = false;
        List<Song> uploadedSongs;
        //List<Event> myEvents;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public bool Banned { get => banned; set => banned = value; }
        public List<Song> UploadedSongs { get => uploadedSongs; set => uploadedSongs = value; }

        public VIPUser(string username, string pw, string name, string lastname)
        {
            id = ++ID_COUNTER;
            Username = username;
            Password = pw;
            Name = name;
            LastName = lastname;
        }
    }
}

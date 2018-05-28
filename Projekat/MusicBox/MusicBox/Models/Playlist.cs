using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public class Playlist
    {
        static int ID_COUNTER = 0;
        int id;
        string name;
        List<Song> songs;

        public int ID { get => id;}
        public string Name { get => name; set => name = value; }
        public List<Song> Songs { get => songs; set => songs = value; }

        Playlist(string name)
        {
            id = ++ID_COUNTER;
            Name = name;
        }
    }
}

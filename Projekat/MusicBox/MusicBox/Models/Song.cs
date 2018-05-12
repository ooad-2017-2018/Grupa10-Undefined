using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public class Song
    {
        static int ID_COUNTER = 0;
        int id;
        string name;
        string genre;
        string description;
        List<string> comments;
        List<float> ratings;
        float currRating;
        string url;

        
        public int ID { get => id;}
        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Description { get => description; set => description = value; }
        public List<string> Comments { get => comments; set => comments = value; }
        public List<float> Ratings { get => ratings; set => ratings = value; }
        public float CurrRating { get => currRating; set => currRating = value; }
        public string Url { get => url; set => url = value; }

        public Song(string name, string genre, string desc)
        {
            id = ++ID_COUNTER;
            Name = name;
            Genre = genre;
            Description = desc;
        }
    }
}

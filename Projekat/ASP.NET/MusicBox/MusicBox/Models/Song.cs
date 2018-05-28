using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBox.Models
{
    public class Song
    {
        int id;
        string name;
        string genre;
        string description;
        float currRating;
        string url;

        [Key]
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Description { get => description; set => description = value; }
        public float CurrRating { get => currRating; set => currRating = value; }
        public string Url { get => url; set => url = value; }

        public virtual ICollection<string> Comments { get; set; }
        public virtual ICollection<float> Ratings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MusicBox.Models
{
    public class Playlist
    {
        int id;
        string name;

        [Key]
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public virtual ICollection<Song> Songs { get; set; }

    }
}
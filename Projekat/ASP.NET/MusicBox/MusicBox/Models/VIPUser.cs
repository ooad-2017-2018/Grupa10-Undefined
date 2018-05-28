using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBox.Models
{
    public class VIPUser : RegisteredUser
    {
        int id;

        [Key]
        public int ID { get => id; set => id = value; }
        public virtual ICollection<Song> UploadedSongs { get; set; }
        public virtual ICollection<Event> MyEvents { get; set; }
        
    }
}
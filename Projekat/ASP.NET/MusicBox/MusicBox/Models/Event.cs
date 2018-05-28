using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MusicBox.Models
{
    public class Event
    {
        string name;
        Location location;
        string description;
        DateTime eventDate;
        int id;

        [Key]
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Location Location { get => location; set => location = value; }
        public string Description { get => description; set => description = value; }
        public DateTime EventDate { get => eventDate; set => eventDate = value; }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public sealed class Location
    {
        int lng;
        int lat;

        public Location(int lng, int lat)
        {
            this.lng = lng;
            this.lat = lat;
        }

        public int Longitude { get => lng; set => lng = value; }
        public int Latitude { get => lat; set => lat = value; }
    }
    public class Event
    {
        string name;
        Location location;
        string description;
        DateTime eventDate;
        int id;

        public Event(string name,Location location, string description, DateTime eventDate, int id)
        {
            this.name = name;
            this.location = location;
            this.description = description;
            this.eventDate = eventDate;
            this.id = id;
        }

        public string Name { get => name; }
        public string Description { get => description;}
        public DateTime EventDate { get => eventDate;}
        public int Id { get => id;}
        public Location Location { get => location;}
    }
}

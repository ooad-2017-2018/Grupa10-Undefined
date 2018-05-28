using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}
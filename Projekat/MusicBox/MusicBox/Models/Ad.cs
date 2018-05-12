using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public enum AdType { SongAd, EvendAd}
    class Ad
    {
        DateTime expirationDate;
        string contentName;
        int id;
        AdType adType;

        public Ad(DateTime expirationDate, string contentName, int id, AdType adType)
        {
            this.expirationDate = expirationDate;
            this.contentName = contentName;
            this.id = id;
            this.adType = adType;
        }

        public DateTime ExpirationDate { get => expirationDate;}
        public string ContentName { get => contentName;}
        public int Id { get => id;}
        public AdType AdType { get => adType;}
    }
}

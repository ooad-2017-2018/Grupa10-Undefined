using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBox.Models
{
    

    public class Ad
    {
        DateTime expirationDate;
        string contentName;
        int id;
        string adType;

        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string ContentName { get => contentName; set => contentName = value; }

        [Key]
        public int ID { get => id; set => id = value; }
        public string AdType { get => adType; set => adType = value; }
    }
}
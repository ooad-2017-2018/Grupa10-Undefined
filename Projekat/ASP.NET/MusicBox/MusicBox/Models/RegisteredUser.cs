using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MusicBox.Models
{
    public class RegisteredUser : Auser
    {
        int id;
        string name;
        string lastName;
        bool banned = false;

        [Key]
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public bool Banned { get => banned; set => banned = value; }
    }
}
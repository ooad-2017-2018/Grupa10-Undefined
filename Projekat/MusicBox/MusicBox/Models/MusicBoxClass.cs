using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Models
{
    public static class MusicBoxClass
    {
        static List<User> users;

        public static List<User> Users { get => users; set => users = value; }
        
    }
}

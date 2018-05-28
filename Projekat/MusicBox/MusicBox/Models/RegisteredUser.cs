 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MusicBox.Models
{
    public class RegisteredUser : User
    {
        static int ID_COUNTER = 0;
        int id;
        string name;
        string lastName;
        bool banned = false;

        public int ID { get => id;}
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public bool Banned { get => banned; set => banned = value; }

        public RegisteredUser(string username, string pw, string name, string lastname)
        {
            id = ++ID_COUNTER;
            Username = username;
            Password = calculateHash(pw);
            Name = name;
            LastName = lastname;
        }

        public static string calculateHash(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            string s = "";
            for (int i = 0; i < hash.Length; i++)
            {
                s = s + (hash[i].ToString("x2"));
            }
            return s;
        }
    }
}

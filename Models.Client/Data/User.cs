using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Data
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; private set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public string Token { get; private set; }
        public User(string username, string email, string password, int xp, int level)
        {
            Username = username;
            EmailAddress = email;
            Password = password;
            Xp = xp;
            Level = level;
        }
        internal User(int id, string username, string email, int xp, int level, string token)
            : this(username, email, null, xp, level)
        {
            Id = id;
            Token = token;
        }
    }
    
}

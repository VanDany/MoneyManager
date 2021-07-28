using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public string Token { get; set; }
        public User(string username, string emailAddress, string password, int xp, int level)
        {
            Username = username;
            EmailAddress = emailAddress;
            Password = password;
            Xp = xp;
            Level = level;
        }
        internal User(int id, string username, string emailAddress, int xp, int level)
            : this(username, emailAddress, null, xp, level)
        {
            Id = id;
        }
    }
}

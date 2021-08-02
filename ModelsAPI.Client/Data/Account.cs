using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Data
{
    public class Account
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public Account(int userId, string description)
        {
            UserId = userId;
            Description = description;
        }
        internal Account(int id, int userId, string description):this(userId, description)
        {
            Id = id;
        }
    }
}

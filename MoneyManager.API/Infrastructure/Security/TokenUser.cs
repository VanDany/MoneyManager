using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Infrastructure.Security
{
    public class TokenUser
    {
        public int Id { get; internal set; }
        public string Username { get; internal set; }
        public string EmailAddress { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Infrastructure.Session
{
    public interface ISessionManager
    {
        UserSession User { get; set; }
        void Clear();
    }
}

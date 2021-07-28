using Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User user);
    }
}

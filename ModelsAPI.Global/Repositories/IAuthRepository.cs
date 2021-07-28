using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        void Register(User entity);
        bool EmailExists(string email);
    }
}

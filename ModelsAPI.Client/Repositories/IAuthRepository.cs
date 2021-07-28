using ModelsAPI.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User entity);
        bool EmailExists(string email);
    }
}

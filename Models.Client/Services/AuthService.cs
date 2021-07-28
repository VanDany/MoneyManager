using Models.Client.Repositories;
using Models.Client.Mappers;
using GR = Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Client.Data;

namespace Models.Client.Services
{
    public class AuthService : IAuthRepository
    {
        public readonly GR.IAuthRepository _globalRepository;

        public AuthService(GR.IAuthRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public User Login(string email, string password)
        {
            return _globalRepository.Login(email, password)?.ToClient();
        }

        public void Register(User user)
        {
            _globalRepository.Register(user.ToGlobal());
        }
    }
}

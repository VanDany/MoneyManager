using ModelsAPI.Client.Repositories;
using ModelsAPI.Client.Data;
using GR = ModelsAPI.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsAPI.Client.Mappers;

namespace ModelsAPI.Client.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly GR.IAuthRepository _globalRepository;

        public AuthService(GR.IAuthRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public bool EmailExists(string email)
        {
            return _globalRepository.EmailExists(email);
        }

        public User Login(string email, string password)
        {
            return _globalRepository.Login(email, password)?.ToClient();
        }

        public void Register(User entity)
        {
            _globalRepository.Register(entity.ToGlobal());
        }
    }
}

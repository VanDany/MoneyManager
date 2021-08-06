using Models.Client.Repositories;
using GR = Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Client.Data;
using Models.Client.Mappers;

namespace Models.Client.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly GR.IAccountRepository _globalRepository;
        public AccountService(GR.IAccountRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Account> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }
        public void Insert(Account category)
        {
            _globalRepository.Insert(category.ToGlobal());
        }
        public void Update(int id, Account category)
        {
            _globalRepository.Update(id, category.ToGlobal());
        }
        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }
        public Account GetAccount(int id)
        {
            return _globalRepository.GetAccount(id)?.ToClient();
        }
    }
}

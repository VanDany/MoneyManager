using ModelsAPI.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using GR = ModelsAPI.Global.Repositories;
using System.Text;
using System.Threading.Tasks;
using ModelsAPI.Client.Data;
using ModelsAPI.Client.Mappers;

namespace ModelsAPI.Client.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly GR.IAccountRepository _globalRepository;

        public AccountService(GR.IAccountRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Account> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }
        public void Insert(Account account)
        {
            _globalRepository.Insert(account.ToGlobal());
        }
        public void Update(int id, Account account)
        {
            _globalRepository.Update(id, account.ToGlobal());
        }
        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }
        public Account GetAccount(int id, int userId)
        {
            return _globalRepository.GetAccount(id, userId)?.ToClient();
        }
    }
}

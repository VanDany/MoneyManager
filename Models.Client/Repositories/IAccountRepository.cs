using Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Get();
        void Insert(Account account);
        void Update(int id, Account account);
        void Delete(int id);
        Account GetAccount(int id);
    }
}

using Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Global.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Get();
        Account GetAccount(int id);
        void Insert(Account account);
        void Update(int id, Account account);
        void Delete(int id);
    }
}

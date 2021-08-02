using ModelsAPI.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Get(int userId);
        void Insert(Account account);

        void Update(int id, Account account);

        void Delete(int id);

        Account GetAccount(int id, int userId);
    }
}

using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Get(int userId);

        Account GetAccount(int id, int userId);

        void Insert(Account category);

        void Update(int id, Account category);

        void Delete(int id);
    }
}

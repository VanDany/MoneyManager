using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get(int userId);

        Transaction GetTransact(int id, int userId);

        void Insert(Transaction transact);

        void Update(int id, Transaction transact);

        void Delete(int id);
    }
}

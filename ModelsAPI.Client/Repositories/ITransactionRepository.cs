using ModelsAPI.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();

        Transaction GetTransact(int id);

        void Insert(Transaction transact);

        void Update(int id, Transaction transact);

        void Delete(int id);
    }
}

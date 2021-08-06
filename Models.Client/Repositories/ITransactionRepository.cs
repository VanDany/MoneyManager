using Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();
        void Insert(Transaction transaction);
        void Update(int id, Transaction transaction);
        void Delete(int id);
        Transaction GetTransact(int id);
    }
}

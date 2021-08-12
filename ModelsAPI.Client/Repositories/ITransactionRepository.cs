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
        IEnumerable<Transaction> Get(int userId);
        public IEnumerable<Transaction> GetPage(int userId, int rows, int pageNumber);

        Transaction GetTransact(int id, int userId);

        void Insert(Transaction transact);

        void Update(int id, Transaction transact);

        void Delete(int id);
    }
}

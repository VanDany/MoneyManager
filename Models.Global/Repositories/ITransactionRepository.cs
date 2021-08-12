using Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Global.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();
        IEnumerable<Transaction> GetPage(int rows, int pageNumber);
        Transaction GetTransact(int id);
        void Insert(Transaction category);
        void Update(int id, Transaction category);
        void Delete(int id);
    }
}

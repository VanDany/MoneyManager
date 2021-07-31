using ModelsAPI.Client.Data;
using ModelsAPI.Client.Repositories;
using System;
using System.Collections.Generic;
using GR = ModelsAPI.Global.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsAPI.Client.Mappers;

namespace ModelsAPI.Client.Services
{
    public class TransactionService : ITransactionRepository
    {
        private readonly GR.ITransactionRepository _globalRepository;

        public TransactionService(GR.ITransactionRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Transaction> Get(int userAccountId)
        {
            return _globalRepository.Get(userAccountId).Select(c => c.ToClient());
        }

        public Transaction GetTransact(int userAccountId, int id)
        {
            return _globalRepository.GetTransact(userAccountId, id)?.ToClient();
        }
        public void Insert(Transaction transact)
        {
            _globalRepository.Insert(transact.ToGlobal());
        }

        public void Update(int id, Transaction transact)
        {
            _globalRepository.Update(id, transact.ToGlobal());
        }
        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }
    }
}

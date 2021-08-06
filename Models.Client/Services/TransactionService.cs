using System;
using System.Collections.Generic;
using GR = Models.Global.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Client.Data;
using Models.Client.Mappers;
using Models.Client.Repositories;

namespace Models.Client.Services
{
    public class TransactionService : ITransactionRepository
    {
        private readonly GR.ITransactionRepository _globalRepository;
        public TransactionService(GR.ITransactionRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Transaction> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }
        public void Insert(Transaction transaction)
        {
            _globalRepository.Insert(transaction.ToGlobal());
        }
        public void Update(int id, Transaction transaction)
        {
            _globalRepository.Update(id, transaction.ToGlobal());
        }
        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }
        public Transaction GetTransact(int id)
        {
            return _globalRepository.GetTransact(id)?.ToClient();
        }
    }
}

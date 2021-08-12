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
        public IEnumerable<Transaction> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }
        public IEnumerable<Transaction> GetPage(int userId, int rows, int pageNumber)
        {
            return _globalRepository.GetPage(userId, rows, pageNumber).Select(c => c.ToClient());
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
        public Transaction GetTransact(int id, int userId)
        {
            return _globalRepository.GetTransact(id, userId)?.ToClient();
        }
    }
}

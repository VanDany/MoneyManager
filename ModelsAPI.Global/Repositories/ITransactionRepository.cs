﻿using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get(int userAccountId);

        Transaction GetTransact(int userAccountId, int id);

        void Insert(Transaction transact);

        void Update(int id, Transaction transact);

        void Delete(int userAccountId, int id);
    }
}

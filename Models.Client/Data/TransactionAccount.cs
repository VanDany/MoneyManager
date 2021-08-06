using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Data
{
    public class TransactionAccount
    {
        public IEnumerable<Account> account { get; set; }
        public IEnumerable<Transaction> transaction { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Data
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int UserAccountId { get; set; }
        public string Description { get; set; }
        public bool ExpenseOrIncome { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public Transaction(int userAccountId, string description, bool expenseOrIncome, double amount, int categoryId)
        {
            UserAccountId = userAccountId;
            Description = description;
            ExpenseOrIncome = expenseOrIncome;
            Amount = amount;
            CategoryId = categoryId;
        }
        internal Transaction(int id, int userAccountId, string description, bool expenseOrIncome, double amount, int categoryId)
            :this(userAccountId, description, expenseOrIncome, amount, categoryId)
        {
            Id = id;
        }

    }
    
}

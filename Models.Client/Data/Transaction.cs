using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Data
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int UserAccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime DateTransact { get; private set; }
        public string Description { get; set; }
        public bool ExpenseOrIncome { get; private set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Transaction(int userAccountId, string description, bool expenseOrIncome, double amount, int categoryId)
        {
            UserAccountId = userAccountId;
            Description = description;
            ExpenseOrIncome = expenseOrIncome;
            Amount = amount;
            CategoryId = categoryId;
        }
        public Transaction(int userAccountId, string accountName, string description, bool expenseOrIncome, double amount, int categoryId, string name)
        {
            UserAccountId = userAccountId;
            AccountName = accountName;
            Description = description;
            ExpenseOrIncome = expenseOrIncome;
            Amount = amount;
            CategoryId = categoryId;
            Name = name;
        }
        internal Transaction(int id, int userAccountId, DateTime dateTransact, string description, bool expenseOrIncome, double amount, int categoryId)
            : this(userAccountId, description, expenseOrIncome, amount, categoryId)
        {
            DateTransact = dateTransact;
            Id = id;
        }
    }
}

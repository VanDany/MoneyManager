using ModelsAPI.Global.Data;
using ModelsAPI.Global.Mappers;
using ModelsAPI.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace ModelsAPI.Global.Services
{
    public class TransactionService : ITransactionRepository
    {
        private readonly Connection _connection;

        public TransactionService(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Transaction> Get()
        {
            Command command = new Command("Select Id, UserAccountId, DateTransact, Description, ExpenseOrIncome, Amount, CategoryId From Transaction", false);
            return _connection.ExecuteReader(command, dr => dr.ToTransaction());
        }

        public Transaction GetTransact(int id)
        {
            Command command = new Command("Select Id, UserAccountId, DateTransact, Description, ExpenseOrIncome, Amount, CategoryId From Transaction WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToTransaction()).SingleOrDefault();
        }

        public void Insert(Transaction transact)
        {
            Command command = new Command("MMSP_AddTransaction", true);
            command.AddParameter("UserAccountId", transact.UserAccountId);
            command.AddParameter("Description", transact.Description);
            command.AddParameter("ExpenseOrIncome", transact.ExpenseOrIncome);
            command.AddParameter("Amount", transact.Amount);
            command.AddParameter("CategoryId", transact.CategoryId);
            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Transaction transact)
        {
            Command command = new Command("Update Transaction SET UserAccount = @UserAccount, DateTransact = GETDATE(), Description = @Description, ExpenseOrIncome = @ExpenseOrIncome, Amount = @Amount, CategoryId = @CategoryId WHERE Id = @Id AND UserAccountId = @UserAccountId", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserAccountId", transact.UserAccountId);
            command.AddParameter("Description", transact.Description);
            command.AddParameter("ExpenseOrIncome", transact.ExpenseOrIncome);
            command.AddParameter("Amount", transact.Amount);
            command.AddParameter("CategoryId", transact.CategoryId);
            _connection.ExecuteNonQuery(command);
        }
        public void Delete(int id)
        {
            Command command = new Command("DELETE FROM [Transaction] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);
        }
    }
}

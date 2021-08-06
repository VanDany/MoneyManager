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
        public IEnumerable<Transaction> Get(int userId)
        {
            Command command = new Command("Select T.Id, UserAccountId, DateTransact, T.[Description], ExpenseOrIncome, Amount, CategoryId From [Transaction] T INNER JOIN UserAccount U ON T.UserAccountId = U.Id WHERE U.UserId = @UserId;", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToTransaction());
        }

        public Transaction GetTransact(int id, int userId)
        {
            Command command = new Command("Select T.Id, UserAccountId, DateTransact, T.[Description], ExpenseOrIncome, Amount, CategoryId From [Transaction] T INNER JOIN UserAccount U ON T.UserAccountId = U.Id WHERE U.UserId = @UserId AND T.Id = @Id;", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
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
            Command command = new Command("Update [Transaction] SET UserAccountId = @UserAccountId, DateTransact = GETDATE(), Description = @Description, ExpenseOrIncome = @ExpenseOrIncome, Amount = @Amount, CategoryId = @CategoryId WHERE Id = @Id AND UserAccountId = @UserAccountId", false);
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

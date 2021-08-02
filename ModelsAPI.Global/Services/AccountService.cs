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
    
    public class AccountService : IAccountRepository
    {
        private readonly Connection _connection;

        public AccountService(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Account> Get(int userId)
        {
            Command command = new Command("Select Id, UserId, Description From [UserAccount] WHERE UserId = @UserId", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToAccount());
        }

        public Account GetAccount(int id, int userId)
        {
            Command command = new Command("Select Id, UserId, Description From [UserAccount] WHERE Id = @Id AND UserId = @UserId;", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToAccount()).SingleOrDefault();
        }

        public void Insert(Account account)
        {
            Command command = new Command("MMSP_AddAccount", true);
            command.AddParameter("UserId", account.UserId);
            command.AddParameter("Description", account.Description);
            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Account account)
        {
            Command command = new Command("Update [UserAccount] SET UserId = @UsertId, Description = @Description WHERE Id = @Id AND UserId = @UserId", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", account.UserId);
            command.AddParameter("Description", account.Description);
            _connection.ExecuteNonQuery(command);
        }
        public void Delete(int id)
        {
            Command command = new Command("DELETE FROM [UserAccount] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);
        }
    }
}

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
    public class AuthService : IAuthRepository
    {
        private readonly Connection _connection;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }
        public bool EmailExists(string email)
        {
            Command command = new Command("Select Count(*) From [User] where EmailAddress = @Email;", false);
            command.AddParameter("Email", email);

            int count = (int)_connection.ExecuteScalar(command);
            return count == 1;
        }

        public User Login(string email, string password)
        {
            Command command = new Command("MMSP_AuthUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Password", password);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User entity)
        {
            Command command = new Command("MMSP_RegisterUser", true);
            command.AddParameter("Username", entity.Username);
            command.AddParameter("Email", entity.EmailAddress);
            command.AddParameter("Password", entity.Password);
            _connection.ExecuteNonQuery(command);
            entity.Password = null;
        }
    }
}

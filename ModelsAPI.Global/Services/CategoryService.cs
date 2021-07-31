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
    public class CategoryService : ICategoryRepository
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get(int userId)
        {
            Command command = new Command("Select Id, Name, BudgetLimit, UserId From Category WHERE UserId = @UserId;", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public void Insert(Category category)
        {
            Command command = new Command("MMSP_AddCategory", true);
            command.AddParameter("Name", category.Name);
            command.AddParameter("BudgetLimit", category.BudgetLimit);
            command.AddParameter("UserId", category.UserId);

            _connection.ExecuteNonQuery(command);
        }
        public void Update(int id, Category category)
        {
            Command command = new Command("Update Category SET Name = @Name, BudgetLimit = @BudgetLimit WHERE Id = @Id AND UserId = @UserId", false);
            command.AddParameter("Id", id);
            command.AddParameter("Name", category.Name);
            command.AddParameter("BudgetLimit", category.BudgetLimit);
            command.AddParameter("UserId", category.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("MMSP_DeleteCategory", true);
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);
        }

        public Category GetCat(int id, int userId)
        {
            Command command = new Command("SELECT Id, Name, BudgetLimit From Category WHERE Id = @Id AND UserId = @UserId", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();

        }
    }
}

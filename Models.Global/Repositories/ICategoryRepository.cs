using Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get(int userId);
        Category GetCat(int id, int userId);
        void Insert(Category category);
        void Update(int id, Category category);
        void Delete(int id);
    }
}

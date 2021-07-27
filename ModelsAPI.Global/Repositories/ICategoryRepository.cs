using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();

        Category GetCat(int id);

        void Insert(Category category);

        void Update(int id, Category category);

        void Delete(int id);
    }
}

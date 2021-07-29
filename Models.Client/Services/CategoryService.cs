using Models.Client.Data;
using Models.Client.Mappers;
using Models.Client.Repositories;
using GR = Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GR.ICategoryRepository _globalRepository;

        public CategoryService(GR.ICategoryRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Category> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }
        public void Insert(Category category)
        {
            _globalRepository.Insert(category.ToGlobal());
        }

        public void Update(int id, Category category)
        {
            _globalRepository.Update(id, category.ToGlobal());
        }

        public void Delete(int userId, int id)
        {
            _globalRepository.Delete(userId, id);
        }

        public Category GetCat(int userId, int id)
        {
            return _globalRepository.GetCat(userId, id)?.ToClient();
        }
    }
}

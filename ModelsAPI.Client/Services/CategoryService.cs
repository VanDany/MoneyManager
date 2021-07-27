using System;
using System.Collections.Generic;
using System.Linq;
using GR = ModelsAPI.Global.Repositories;
using System.Text;
using System.Threading.Tasks;
using ModelsAPI.Client.Data;
using ModelsAPI.Client.Mappers;
using ModelsAPI.Client.Repositories;

namespace ModelsAPI.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GR.ICategoryRepository _globalRepository;

        public CategoryService(GR.ICategoryRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }
        public IEnumerable<Category> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }
        public void Insert(Category category)
        {
            _globalRepository.Insert(category.ToGlobal());
        }

        public void Update(int id, Category category)
        {
            _globalRepository.Update(id, category.ToGlobal());
        }

        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }

        public Category GetCat(int id)
        {
            return _globalRepository.GetCat(id)?.ToClient();
        }
    }
}

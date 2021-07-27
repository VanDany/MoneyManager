using Models.Client.Data;
using G = Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static G.Category ToGlobal(this Category entity)
        {
            return new G.Category()
            {
                Id = entity.Id,
                Name = entity.Name,
                BudgetLimit = entity.BudgetLimit
            };
        }

        internal static Category ToClient(this G.Category entity)
        {
            return new Category(entity.Id, entity.Name, entity.BudgetLimit);
        }
    }
}

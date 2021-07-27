using ModelsAPI.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Mappers
{
    internal static class DataRecord
    {
        internal static Category ToCategory(this IDataRecord dataRecord)
        {
            return new Category()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                BudgetLimit = (dataRecord["BudgetLimit"] is DBNull)?null:(double?)dataRecord["BudgetLimit"]
            };
        }
    }
}

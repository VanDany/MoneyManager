﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Global.Data;
namespace Models.Global.Mappers
{
    internal static class DataRecord
    {
        internal static Category ToCategory(this IDataRecord dataRecord)
        {
            return new Category()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                BudgetLimit = (dataRecord["BudgetLimit"] is DBNull) ? null : (double?)dataRecord["BudgetLimit"],
                UserId = (int)dataRecord["UserId"]
            };
        }
        internal static Account ToAccount(this IDataRecord dataRecord)
        {
            return new Account()
            {
                Id = (int)dataRecord["Id"],
                UserId = (int)dataRecord["UserId"],
                Description = (string)dataRecord["Description"],
            };
        }
    }
}

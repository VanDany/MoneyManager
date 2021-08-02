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
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                Username = (string)dataRecord["Username"],
                EmailAddress = (string)dataRecord["EmailAddress"],
                Password = null
            };
        }
        internal static Category ToCategory(this IDataRecord dataRecord)
        {
            return new Category()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                BudgetLimit = (dataRecord["BudgetLimit"] is DBNull)?null:(double?)dataRecord["BudgetLimit"]
            };
        }
        internal static Transaction ToTransaction(this IDataRecord dataRecord)
        {
            return new Transaction()
            {
                Id = (int)dataRecord["Id"],
                UserAccountId = (int)dataRecord["UserAccountId"],
                DateTransact = (DateTime)dataRecord["DateTransact"],
                Description= (dataRecord["Description"] is DBNull) ? null : (string)dataRecord["Description"],
                ExpenseOrIncome = (bool)dataRecord["ExpenseOrIncome"],
                Amount = (double)dataRecord["Amount"],
                CategoryId = (int)dataRecord["CategoryId"]
            };
        }
        internal static Account ToAccount(this IDataRecord dataRecord)
        {
            return new Account()
            {
                Id = (int)dataRecord["Id"],
                UserId = (int)dataRecord["UserId"],
                Description = (dataRecord["Description"] is DBNull) ? null : (string)dataRecord["Description"]
            };
        }
    }
}
